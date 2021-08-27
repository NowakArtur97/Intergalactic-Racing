using NowakArtur97.IntergalacticRacing.Core;

namespace NowakArtur97.IntergalacticRacing.StateMachine
{
    public class VehicleTurnState : TurnState
    {
        private Vehicle _vehicle;

        // TODO: CarMoveState: Move to data file(?)
        public float accelerationFactor = 30.0f;
        public float maxSpeed = 30.0f;
        public float reverseMaxSpeed = 20f;
        public float driftFactor = 0.95f;
        public float turnFactor = 3.5f;

        public VehicleTurnState(Vehicle Entity) : base(Entity)
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
                if (!_vehicle.VehicleChecks.CheckIsTurning())
                {
                    Entity.StateMachine.ChangeState(_vehicle.VehicleGoStraightState);
                }
                else if (!_vehicle.VehicleChecks.CheckIsMoving())
                {
                    Entity.StateMachine.ChangeState(_vehicle.VehicleSlowDownState);
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
