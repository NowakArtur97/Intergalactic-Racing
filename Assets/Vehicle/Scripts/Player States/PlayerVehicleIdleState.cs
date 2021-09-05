using NowakArtur97.IntergalacticRacing.Core;

namespace NowakArtur97.IntergalacticRacing.StateMachine
{
    public class PlayerVehicleIdleState : VehicleIdleState
    {
        public PlayerVehicleIdleState(Vehicle Entity) : base(Entity)
        {
        }

        public override void LogicUpdate()
        {
            base.LogicUpdate();

            if (!IsExitingState && IsMoving)
            {
                Entity.StateMachine.ChangeState(Vehicle.VehicleGoStraightState);
            }
        }
    }
}
