using NowakArtur97.IntergalacticRacing.Core;

namespace NowakArtur97.IntergalacticRacing.StateMachine
{
    public class PlayerVehicleIdleState : VehicleIdleState
    {
        private PlayerVehicle _playerVehicle;

        public PlayerVehicleIdleState(PlayerVehicle Entity) : base(Entity)
        {
            _playerVehicle = Entity;
        }

        public override void LogicUpdate()
        {
            base.LogicUpdate();

            if (!IsExitingState && IsMoving)
            {
                Entity.StateMachine.ChangeState(_playerVehicle.PlayerVehicleGoStraightState);
            }
        }
    }
}
