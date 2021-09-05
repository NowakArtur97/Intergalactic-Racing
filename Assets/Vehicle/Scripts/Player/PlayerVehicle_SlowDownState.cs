using NowakArtur97.IntergalacticRacing.Core;

namespace NowakArtur97.IntergalacticRacing.StateMachine
{
    public class PlayerVehicle_SlowDownState : Vehicle_SlowDownState
    {
        private PlayerVehicle _playerVehicle;

        public PlayerVehicle_SlowDownState(PlayerVehicle Entity) : base(Entity)
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
                    Entity.StateMachine.ChangeState(_playerVehicle.IdleState);
                }
                else if (IsTurning)
                {
                    Entity.StateMachine.ChangeState(_playerVehicle.TurnState);
                }
                else if (IsMoving)
                {
                    Entity.StateMachine.ChangeState(_playerVehicle.GoStraightState);
                }
            }
        }
    }
}
