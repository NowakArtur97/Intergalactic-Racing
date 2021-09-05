using NowakArtur97.IntergalacticRacing.Core;

namespace NowakArtur97.IntergalacticRacing.StateMachine
{
    public class AIPlayerChaseVehicle_IdleState : Vehicle_IdleState
    {
        private AIPlayerChaseVehicle _aIVehicle;

        public AIPlayerChaseVehicle_IdleState(AIPlayerChaseVehicle Entity) : base(Entity)
        {
            _aIVehicle = Entity;
        }

        public override void LogicUpdate()
        {
            base.LogicUpdate();

            if (!IsExitingState && PlayerTransform)
            {
                _aIVehicle.ChaseState.SetPlayerTransform(PlayerTransform);
                Entity.StateMachine.ChangeState(_aIVehicle.ChaseState);
            }
        }
    }
}
