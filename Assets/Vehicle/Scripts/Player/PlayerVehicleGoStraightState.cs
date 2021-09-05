using NowakArtur97.IntergalacticRacing.Core;

namespace NowakArtur97.IntergalacticRacing.StateMachine
{
    public class PlayerVehicleGoStraightState : VehicleGoStraightState
    {
        private PlayerVehicle _playerVehicle;

        public PlayerVehicleGoStraightState(PlayerVehicle Entity) : base(Entity)
        {
            _playerVehicle = Entity;
        }

        public override void LogicUpdate()
        {
            base.LogicUpdate();

            if (!IsExitingState)
            {
                if (!IsMoving)
                {
                    Entity.StateMachine.ChangeState(_playerVehicle.PlayerVehicleSlowDownState);
                }
                else if (IsTurning)
                {
                    Entity.StateMachine.ChangeState(_playerVehicle.PlayerVehicleTurnState);
                }
            }
        }
    }
}
