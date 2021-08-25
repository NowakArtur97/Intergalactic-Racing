using NowakArtur97.IntergalacticRacing.Core;

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
    }
}
