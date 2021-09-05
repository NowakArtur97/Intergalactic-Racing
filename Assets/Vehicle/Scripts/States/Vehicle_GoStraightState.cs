using NowakArtur97.IntergalacticRacing.Core;

namespace NowakArtur97.IntergalacticRacing.StateMachine
{
    public abstract class Vehicle_GoStraightState : Vehicle_MoveState
    {
        public Vehicle_GoStraightState(Vehicle Entity) : base(Entity)
        {
        }

        public override void PhysicsUpdate()
        {
            if (HasNotExceededMaximumSpeed(Vehicle.VehicleData.forwardSpeed, Vehicle.VehicleData.backwardSpeed))
            {
                Vehicle.ApplyEngineForce(HasForwardVelocity
                    ? Vehicle.VehicleData.forwardSpeed.accelerationFactor : Vehicle.VehicleData.backwardSpeed.accelerationFactor);
            }

            base.PhysicsUpdate();
        }
    }
}
