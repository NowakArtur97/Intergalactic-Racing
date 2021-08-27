using NowakArtur97.IntergalacticRacing.Core;

namespace NowakArtur97.IntergalacticRacing.StateMachine
{
    public class VehicleIdleState : IdleState
    {
        private Vehicle _vehicle;

        public VehicleIdleState(Vehicle Entity) : base(Entity)
        {
            _vehicle = Entity;
        }

        public override void LogicUpdate()
        {
            base.LogicUpdate();

            if (!IsExitingState && _vehicle.VehicleChecks.CheckIsMoving())
            {
                Entity.StateMachine.ChangeState(_vehicle.VehicleGoStraightState);
            }
        }
    }
}