using NowakArtur97.IntergalacticRacing.Core;

namespace NowakArtur97.IntergalacticRacing.StateMachine
{
    public class CarMoveState : MoveState
    {
        // TODO: CarMoveState: Refactor
        private Car _car;

        public CarMoveState(Car Entity, FiniteStateMachine StateMachine, CoreContainer CoreContainer)
           : base(Entity, StateMachine, CoreContainer)
        {
            _car = Entity;
        }

        public override void LogicUpdate()
        {
            base.LogicUpdate();

            if (IsNotMoving)
            {
                Entity.StateMachine.ChangeState(_car.CarIdleState);
            }
        }
    }
}
