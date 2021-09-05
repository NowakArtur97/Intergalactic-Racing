using NowakArtur97.IntergalacticRacing.Core;

namespace NowakArtur97.IntergalacticRacing.StateMachine
{
    public abstract class VehicleIdleState : VehicleState
    {
        protected bool IsMoving { get; private set; }

        public VehicleIdleState(Vehicle Entity) : base(Entity)
        {
        }

        public override void Enter()
        {
            base.Enter();

            Entity.CoreContainer.Movement.SetVelocityZero();
        }

        public override void DoChecks()
        {
            base.DoChecks();

            IsMoving = Vehicle.VehicleChecks.CheckIsMoving();
        }
    }
}