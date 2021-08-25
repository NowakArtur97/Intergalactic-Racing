using NowakArtur97.IntergalacticRacing.Core;

namespace NowakArtur97.IntergalacticRacing.StateMachine
{
    public abstract class State
    {
        protected readonly Entity Entity;
        protected readonly CoreContainer CoreContainer;
        protected readonly FiniteStateMachine StateMachine;

        public State(Entity Entity, FiniteStateMachine StateMachine, CoreContainer CoreContainer)
        {
            this.Entity = Entity;
            this.StateMachine = StateMachine;
            this.CoreContainer = CoreContainer;
        }

        public virtual void Enter() => DoChecks();

        public virtual void Exit() { }

        public virtual void LogicUpdate() { }

        public virtual void PhysicsUpdate() => DoChecks();

        public virtual void DoChecks() { }
    }
}