using NowakArtur97.IntergalacticRacing.Core;

namespace NowakArtur97.IntergalacticRacing.StateMachine
{
    public class PlayerVehicleGoStraightState : VehicleGoStraightState
    {
        public PlayerVehicleGoStraightState(Vehicle Entity) : base(Entity)
        {
        }

        public override void LogicUpdate()
        {
            base.LogicUpdate();

            if (!IsExitingState)
            {
                if (!IsMoving)
                {
                    Entity.StateMachine.ChangeState(Vehicle.VehicleSlowDownState);
                }
                else if (IsTurning)
                {
                    Entity.StateMachine.ChangeState(Vehicle.VehicleTurnState);
                }
            }
        }
    }
}
