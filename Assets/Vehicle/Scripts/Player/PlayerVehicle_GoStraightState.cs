using NowakArtur97.IntergalacticRacing.Core;

namespace NowakArtur97.IntergalacticRacing.StateMachine
{
    public class PlayerVehicle_GoStraightState : Vehicle_GoStraightState
    {
        private PlayerVehicle _playerVehicle;

        public PlayerVehicle_GoStraightState(PlayerVehicle Entity) : base(Entity)
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
                    Entity.StateMachine.ChangeState(_playerVehicle.SlowDownState);
                }
                else if (IsTurning)
                {
                    Entity.StateMachine.ChangeState(_playerVehicle.TurnState);
                }
            }
        }
    }
}
