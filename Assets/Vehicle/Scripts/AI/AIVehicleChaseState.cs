using NowakArtur97.IntergalacticRacing.Core;
using UnityEngine;

namespace NowakArtur97.IntergalacticRacing.StateMachine
{
    public class AIVehicleChaseState : VehicleMoveState
    {
        private AIVehicle _aIVehicle;

        private Transform _playerTransform;

        private Vector2 _vectorToTarget;
        private float _angleToTarget;
        private float _steerAmount;

        public AIVehicleChaseState(AIVehicle Entity) : base(Entity)
        {
            _aIVehicle = Entity;
        }

        public override void LogicUpdate()
        {
            base.LogicUpdate();

            if (!IsExitingState)
            {
                if (_playerTransform)
                {
                    Chase();
                }
                else
                {
                    Entity.StateMachine.ChangeState(_aIVehicle.AIVehicleIdleState);
                }
            }
        }

        public override void PhysicsUpdate()
        {
            base.PhysicsUpdate();

            Vehicle.ApplyEngineForce(HasForwardVelocity
                   ? Vehicle.VehicleData.forwardSpeed.accelerationFactor : Vehicle.VehicleData.backwardSpeed.accelerationFactor);
        }

        private void Chase()
        {
            _vectorToTarget = _playerTransform.position - Entity.transform.position;
            _vectorToTarget.Normalize();

            _angleToTarget = Vector2.SignedAngle(Entity.transform.up, _vectorToTarget) * -1;

            _steerAmount = Mathf.Clamp(_angleToTarget, -1.0f, 1.0f);

            Vehicle.MovementInput.Set(_steerAmount, 1.0f);
        }

        public void SetPlayerTransform(Transform playerTransform) => _playerTransform = playerTransform;
    }
}
