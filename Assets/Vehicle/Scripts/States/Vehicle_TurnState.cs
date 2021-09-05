using NowakArtur97.IntergalacticRacing.Core;

namespace NowakArtur97.IntergalacticRacing.StateMachine
{
    public abstract class Vehicle_TurnState : Vehicle_MoveState
    {
        public Vehicle_TurnState(Vehicle Entity) : base(Entity)
        {
        }

        public override void PhysicsUpdate()
        {
            if (HasNotExceededMaximumSpeed(Vehicle.VehicleData.turningForwardSpeed, Vehicle.VehicleData.turningBackwardSpeed))
            {
                Vehicle.ApplyEngineForce(HasForwardVelocity
                    ? Vehicle.VehicleData.turningForwardSpeed.accelerationFactor : Vehicle.VehicleData.turningBackwardSpeed.accelerationFactor);
            }

            base.PhysicsUpdate();
        }
    }
}
