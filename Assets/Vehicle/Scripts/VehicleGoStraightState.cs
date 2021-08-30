using NowakArtur97.IntergalacticRacing.Core;

namespace NowakArtur97.IntergalacticRacing.StateMachine
{
    public class VehicleGoStraightState : State
    {
        private Vehicle _vehicle;

        public VehicleGoStraightState(Vehicle Entity) : base(Entity)
        {
            _vehicle = Entity;
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

            if (!(_vehicle.VelocityVsUp > _vehicle.VehicleData.forwardMaxSpeed && _vehicle.VehicleChecks.CheckIsMovingForward())
                && !(_vehicle.VelocityVsUp < -_vehicle.VehicleData.reverseMaxSpeed && _vehicle.VehicleChecks.CheckIsMovingBackward()))
            {
                _vehicle.ApplyEngineForce(_vehicle.VehicleData.forwardAccelerationFactor);
            }

            _vehicle.KillOrthogonalVelocity(_vehicle.VehicleData.driftFactor);

            _vehicle.ApplySteering(_vehicle.VehicleData.turnFactor);
        }
    }
}
