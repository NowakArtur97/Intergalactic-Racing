using NowakArtur97.IntergalacticRacing.Core;

namespace NowakArtur97.IntergalacticRacing.StateMachine
{
    public class VehicleIdleState : IdleState
    {
        // TODO: CarIdleState: Refactor
        private Vehicle _vehicle;

        public VehicleIdleState(Vehicle Entity, FiniteStateMachine StateMachine, CoreContainer CoreContainer)
            : base(Entity, StateMachine, CoreContainer)
        {
            _vehicle = Entity;
        }

        public override void LogicUpdate()
        {
            base.LogicUpdate();

            if (IsActive)
            {
                Entity.StateMachine.ChangeState(_vehicle.VehicleMoveState);
            }
        }

        // TODO: CarIdleState: Refactor with parent
        protected override bool CheckIsActive() => _vehicle.MovementInput.y != 0;
    }
}