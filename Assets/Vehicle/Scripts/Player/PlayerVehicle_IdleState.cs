using NowakArtur97.IntergalacticRacing.Core;

namespace NowakArtur97.IntergalacticRacing.StateMachine
{
    public class PlayerVehicle_IdleState : Vehicle_IdleState
    {
        private PlayerVehicle _playerVehicle;

        public PlayerVehicle_IdleState(PlayerVehicle Entity) : base(Entity)
        {
            _playerVehicle = Entity;
        }

        public override void LogicUpdate()
        {
            base.LogicUpdate();

            if (!IsExitingState && IsMoving)
            {
                Entity.StateMachine.ChangeState(_playerVehicle.GoStraightState);
            }
        }
    }
}
