using NowakArtur97.IntergalacticRacing.Core;
using UnityEngine;

namespace NowakArtur97.IntergalacticRacing.StateMachine
{
    public abstract class MoveState : State
    {
        protected bool IsNotMoving { get; private set; }

        public MoveState(Entity Entity, FiniteStateMachine StateMachine, CoreContainer CoreContainer)
            : base(Entity, StateMachine, CoreContainer)
        { }

        public override void DoChecks()
        {
            base.DoChecks();

            IsNotMoving = CheckIsNotMoving();
        }

        protected abstract bool CheckIsNotMoving();
    }
}