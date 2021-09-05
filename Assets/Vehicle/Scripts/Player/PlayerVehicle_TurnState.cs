using NowakArtur97.IntergalacticRacing.Core;

namespace NowakArtur97.IntergalacticRacing.StateMachine
{
    public class PlayerVehicle_TurnState : Vehicle_TurnState
    {
        private PlayerVehicle _playerVehicle;

        public PlayerVehicle_TurnState(PlayerVehicle Entity) : base(Entity)
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
                    Entity.StateMachine.ChangeState(_playerVehicle.GoStraightState);
                }
                else if (!IsMoving)
                {
                    Entity.StateMachine.ChangeState(_playerVehicle.SlowDownState);
                }
            }
        }
    }
}
