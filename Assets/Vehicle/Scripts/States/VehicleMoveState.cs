using NowakArtur97.IntergalacticRacing.Core;

namespace NowakArtur97.IntergalacticRacing.StateMachine
{
    public abstract class VehicleMoveState : State
    {
        private Vehicle _vehicle;

        protected bool HasForwardVelocity;
        protected bool HasBackwardVelocity;

        public VehicleMoveState(Vehicle Entity) : base(Entity)
        {
            _vehicle = Entity;
        }

        public override void LogicUpdate()
        {
            base.LogicUpdate();

            HasForwardVelocity = _vehicle.CoreContainer.Movement.HasForwardVelocity();
            HasBackwardVelocity = _vehicle.CoreContainer.Movement.HasBackwardVelocity();
        }

        public override void PhysicsUpdate()
        {
            base.PhysicsUpdate();

            _vehicle.KillOrthogonalVelocity(_vehicle.VehicleData.driftFactor);

            _vehicle.ApplySteering(_vehicle.VehicleData.turnFactor);
        }
    }
}
