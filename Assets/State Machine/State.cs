using NowakArtur97.IntergalacticRacing.Core;
using UnityEngine;

namespace NowakArtur97.IntergalacticRacing.StateMachine
{
    public abstract class State
    {
        protected readonly Entity Entity;

        protected bool IsExitingState;

        public State(Entity Entity)
        {
            this.Entity = Entity;
        }

        public virtual void Enter()
        {
            DoChecks();

            IsExitingState = false;

            //Debug.Log($"State: {GetType().Name}");
        }

        public virtual void Exit() => IsExitingState = true;

        public virtual void LogicUpdate() { }

        public virtual void PhysicsUpdate() => DoChecks();

        public virtual void DoChecks() { }
    }
}