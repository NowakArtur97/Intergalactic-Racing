using NowakArtur97.IntergalacticRacing.Core;

namespace NowakArtur97.IntergalacticRacing.StateMachine
{
    public class PlayerVehicleSlowDownState : VehicleSlowDownState
    {
        private PlayerVehicle _playerVehicle;

        public PlayerVehicleSlowDownState(PlayerVehicle Entity) : base(Entity)
        {
            _playerVehicle = Entity;
        }

        public override void LogicUpdate()
        {
            base.LogicUpdate();

            if (!IsExitingState)
            {
                if (HasStopped)
                {
                    Entity.StateMachine.ChangeState(_playerVehicle.PlayerVehicleIdleState);
                }
                else if (IsTurning)
                {
                    Entity.StateMachine.ChangeState(_playerVehicle.PlayerVehicleTurnState);
                }
                else if (IsMoving)
                {
                    Entity.StateMachine.ChangeState(_playerVehicle.PlayerVehicleGoStraightState);
                }
            }
        }
    }
}
