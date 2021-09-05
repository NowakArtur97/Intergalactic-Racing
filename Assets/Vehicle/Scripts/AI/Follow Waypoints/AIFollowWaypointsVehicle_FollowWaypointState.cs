using NowakArtur97.IntergalacticRacing.Core;
using System;
using System.Linq;
using UnityEngine;

namespace NowakArtur97.IntergalacticRacing.StateMachine
{
    // TODO: Refactor with Chase state
    public class AIFollowWaypointsVehicle_FollowWaypointState : Vehicle_MoveState
    {
        private AIFollowWaypointsVehicle _aIVehicle;

        private WaypointNode _currentWaypoint;

        private Vector2 _vectorToTarget;
        private float _angleToTarget;
        private float _steerAmount;

        public AIFollowWaypointsVehicle_FollowWaypointState(AIFollowWaypointsVehicle Entity) : base(Entity)
        {
            _aIVehicle = Entity;
        }

        public override void Enter()
        {
            base.Enter();

            _currentWaypoint = _aIVehicle.Waypoints[0];
        }

        public override void LogicUpdate()
        {
            base.LogicUpdate();

            if (_currentWaypoint == null)
            {
                _currentWaypoint = _aIVehicle.Waypoints[0];
            }

            if (!IsExitingState)
            {
                if (IsCloseToWaypoint())
                {
                    ChangeWaypoint();
                }
                else
                {
                    Follow();
                }
            }
        }

        public override void PhysicsUpdate()
        {
            base.PhysicsUpdate();

            Vehicle.ApplyEngineForce(Vehicle.VehicleData.forwardSpeed.accelerationFactor);
        }

        private void Follow()
        {
            _vectorToTarget = _currentWaypoint.transform.position - Entity.transform.position;
            _vectorToTarget.Normalize();

            _angleToTarget = Vector2.SignedAngle(Entity.transform.up, _vectorToTarget) * -1;

            _steerAmount = Mathf.Clamp(_angleToTarget, -1.0f, 1.0f);

            Vehicle.MovementInput.Set(_steerAmount, ApplyThrottleOrBrake());
        }

        private float ApplyThrottleOrBrake()
        {
            Debug.Log(1.05f - Math.Abs(_steerAmount) / 1.0f);
            return 1.05f - Math.Abs(_steerAmount) / 1.0f;
        }

        private void ChangeWaypoint() =>
            _currentWaypoint = _currentWaypoint.NextWaypoints[UnityEngine.Random.Range(0, _currentWaypoint.NextWaypoints.Length)];

        private bool IsCloseToWaypoint() =>
            (_currentWaypoint.transform.position - Entity.transform.position).magnitude <= _currentWaypoint.MinDistanceToReach;
    }
}
