using NowakArtur97.IntergalacticRacing.Core;

namespace NowakArtur97.IntergalacticRacing.StateMachine
{
    public class VehicleGoStraightState : GoStraightState
    {
        // TODO: Move to data file(?)
        public float accelerationFactor = 30.0f;
        public float maxSpeed = 20.0f;
        public float reverseMaxSpeed = 10.0f;
        public float driftFactor = 0.95f;
        public float turnFactor = 3.5f;

        private Vehicle _vehicle;

        public VehicleGoStraightState(Vehicle Entity) : base(Entity)
        {
            _vehicle = Entity;
        }

        public override void Enter()
        {
            base.Enter();

            Entity.CoreContainer.Movement.ResetDrag();
        }

        public override void LogicUpdate()
        {
            base.LogicUpdate();

            if (!IsExitingState)
            {
                if (!_vehicle.VehicleChecks.CheckIsMoving())
                {
                    Entity.StateMachine.ChangeState(_vehicle.VehicleSlowDownState);
                }
                else if (_vehicle.VehicleChecks.CheckIsTurning())
                {
                    Entity.StateMachine.ChangeState(_vehicle.VehicleTurnState);
                }
            }
        }

        public override void PhysicsUpdate()
        {
            base.PhysicsUpdate();

            if (!(_vehicle.VelocityVsUp > maxSpeed && _vehicle.VehicleChecks.CheckIsMovingForward())
               && !(_vehicle.VelocityVsUp < -reverseMaxSpeed && _vehicle.VehicleChecks.CheckIsMovingBackward()))
            {
                _vehicle.ApplyEngineForce(accelerationFactor);
            }

            _vehicle.KillOrthogonalVelocity(driftFactor);

            _vehicle.ApplySteering(turnFactor);
        }
    }
}
