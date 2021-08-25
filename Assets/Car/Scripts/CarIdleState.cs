using NowakArtur97.IntergalacticRacing.Core;
using UnityEngine;

namespace NowakArtur97.IntergalacticRacing.StateMachine
{
    public class CarIdleState : IdleState
    {
        // TODO: CarIdleState: Refactor
        private Car _car;

        public CarIdleState(Car Entity, FiniteStateMachine StateMachine, CoreContainer CoreContainer)
            : base(Entity, StateMachine, CoreContainer)
        {
            _car = Entity;
        }

        public override void LogicUpdate()
        {
            base.LogicUpdate();

            if (IsMoving)
            {
                Entity.StateMachine.ChangeState(_car.CarMoveState);
            }
        }

        // TODO: CarIdleState: Refactor with parent
        protected override bool CheckIsMoving() => _car.MovementInput.y != 0;
    }
}