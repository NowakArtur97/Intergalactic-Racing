using NowakArtur97.IntergalacticRacing.Core;

namespace NowakArtur97.IntergalacticRacing.StateMachine
{
    public class VehicleGoStraightState : VehicleMoveState
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
            if (!(_vehicle.VelocityVsUp > _vehicle.VehicleData.forwardSpeed.maxSpeed && HasForwardVelocity)
                && !(_vehicle.VelocityVsUp < -_vehicle.VehicleData.backwardSpeed.maxSpeed && HasBackwardVelocity))
            {
                _vehicle.ApplyEngineForce(HasForwardVelocity
                    ? _vehicle.VehicleData.forwardSpeed.accelerationFactor : _vehicle.VehicleData.backwardSpeed.accelerationFactor);
            }

            base.PhysicsUpdate();
        }
    }
}