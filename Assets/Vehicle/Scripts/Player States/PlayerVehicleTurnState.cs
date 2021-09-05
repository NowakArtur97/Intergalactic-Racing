using NowakArtur97.IntergalacticRacing.Core;

namespace NowakArtur97.IntergalacticRacing.StateMachine
{
    public class PlayerVehicleTurnState : VehicleTurnState
    {
        public PlayerVehicleTurnState(Vehicle Entity) : base(Entity)
        {
        }

        public override void LogicUpdate()
        {
            base.LogicUpdate();

            if (!IsExitingState)
            {
                if (!IsTurning)
                {
                    Entity.StateMachine.ChangeState(Vehicle.VehicleGoStraightState);
                }
                else if (!IsMoving)
                {
                    Entity.StateMachine.ChangeState(Vehicle.VehicleSlowDownState);
                }
            }
        }
    }
}
