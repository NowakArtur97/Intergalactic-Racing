using NowakArtur97.IntergalacticRacing.Core;
using UnityEngine;

namespace NowakArtur97.IntergalacticRacing.StateMachine
{
    public abstract class IdleState : State
    {
        protected bool IsMoving { get; private set; }

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

            IsMoving = CheckIsMoving();
        }

        private bool CheckIsMoving() => Entity.CoreContainer.Movement.CurrentVelocity != Vector2.zero;
    }
}