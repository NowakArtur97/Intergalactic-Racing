using NowakArtur97.IntergalacticRacing.Core;

namespace NowakArtur97.IntergalacticRacing.StateMachine
{
    public class PlayerVehicleSlowDownState : VehicleSlowDownState
    {
        public PlayerVehicleSlowDownState(Vehicle Entity) : base(Entity)
        {
        }

        public override void LogicUpdate()
        {
            base.LogicUpdate();

            if (!IsExitingState)
            {
                if (HasStopped)
                {
                    Entity.StateMachine.ChangeState(Vehicle.VehicleIdleState);
                }
                else if (IsTurning)
                {
                    Entity.StateMachine.ChangeState(Vehicle.VehicleTurnState);
                }
                else if (IsMoving)
                {
                    Entity.StateMachine.ChangeState(Vehicle.VehicleGoStraightState);
                }
            }
        }
    }
}
