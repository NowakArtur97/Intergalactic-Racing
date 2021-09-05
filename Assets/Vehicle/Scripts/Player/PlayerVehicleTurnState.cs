using NowakArtur97.IntergalacticRacing.Core;

namespace NowakArtur97.IntergalacticRacing.StateMachine
{
    public class PlayerVehicleTurnState : VehicleTurnState
    {
        private PlayerVehicle _playerVehicle;

        public PlayerVehicleTurnState(PlayerVehicle Entity) : base(Entity)
        {
            _playerVehicle = Entity;
        }

        public override void LogicUpdate()
        {
            base.LogicUpdate();

            if (!IsExitingState)
            {
                if (!IsTurning)
                {
                    Entity.StateMachine.ChangeState(_playerVehicle.VehicleGoStraightState);
                }
                else if (!IsMoving)
                {
                    Entity.StateMachine.ChangeState(_playerVehicle.VehicleSlowDownState);
                }
            }
        }
    }
}
