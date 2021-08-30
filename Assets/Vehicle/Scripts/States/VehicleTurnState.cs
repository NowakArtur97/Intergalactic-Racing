using NowakArtur97.IntergalacticRacing.Core;

namespace NowakArtur97.IntergalacticRacing.StateMachine
{
    public class VehicleTurnState : VehicleMoveState
    {
        private Vehicle _vehicle;

        public VehicleTurnState(Vehicle Entity) : base(Entity)
        {
            _vehicle = Entity;
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
            if (HasNotExceededMaximumSpeed(_vehicle.VehicleData.turningForwardSpeed, _vehicle.VehicleData.turningBackwardSpeed))
            {
                _vehicle.ApplyEngineForce(HasForwardVelocity
                    ? _vehicle.VehicleData.turningForwardSpeed.accelerationFactor : _vehicle.VehicleData.turningBackwardSpeed.accelerationFactor);
            }

            base.PhysicsUpdate();
        }
    }
}
