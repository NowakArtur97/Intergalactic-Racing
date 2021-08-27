using NowakArtur97.IntergalacticRacing.Core;

namespace NowakArtur97.IntergalacticRacing.StateMachine
{
    public abstract class IdleState : State
    {
        protected bool IsActive { get; private set; }

        public IdleState(Entity Entity, FiniteStateMachine StateMachine, CoreContainer CoreContainer)
            : base(Entity, StateMachine, CoreContainer)
        { }

        public override void Enter()
        {
            base.Enter();

            Entity.CoreContainer.Movement.SetVelocityZero();
        }

        public override void DoChecks()
        {
            base.DoChecks();

            IsActive = CheckIsActive();
        }

        protected abstract bool CheckIsActive();
    }
}