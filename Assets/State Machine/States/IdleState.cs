using NowakArtur97.IntergalacticRacing.Core;

namespace NowakArtur97.IntergalacticRacing.StateMachine
{
    public abstract class IdleState : State
    {
        public IdleState(Entity Entity, CoreContainer CoreContainer) : base(Entity, CoreContainer)
        { }

        public override void Enter()
        {
            base.Enter();

            Entity.CoreContainer.Movement.SetVelocityZero();
        }
    }
}