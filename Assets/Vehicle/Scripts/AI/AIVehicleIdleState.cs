using NowakArtur97.IntergalacticRacing.Core;

namespace NowakArtur97.IntergalacticRacing.StateMachine
{
    public class AIVehicleIdleState : VehicleIdleState
    {
        private AIVehicle _aIVehicle;

        public AIVehicleIdleState(AIVehicle Entity) : base(Entity)
        {
            _aIVehicle = Entity;
        }

        public override void LogicUpdate()
        {
            base.LogicUpdate();

            if (!IsExitingState && PlayerTransform)
            {
                _aIVehicle.AIVehicleChaseState.SetPlayerTransform(PlayerTransform);
                Entity.StateMachine.ChangeState(_aIVehicle.AIVehicleChaseState);
            }
        }
    }
}
