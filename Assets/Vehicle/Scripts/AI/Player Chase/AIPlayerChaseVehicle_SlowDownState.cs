using NowakArtur97.IntergalacticRacing.Core;
using UnityEngine;

namespace NowakArtur97.IntergalacticRacing.StateMachine
{
    public class AIPlayerChaseVehicle_SlowDownState : Vehicle_SlowDownState
    {
        private AIPlayerChaseVehicle _aiVehicle;

        public AIPlayerChaseVehicle_SlowDownState(AIPlayerChaseVehicle Entity) : base(Entity)
        {
            _aiVehicle = Entity;
        }

        public override void LogicUpdate()
        {
            base.LogicUpdate();

            if (!IsExitingState)
            {
                if (PlayerTransform)
                {
                    _aiVehicle.ChaseState.SetPlayerTransform(PlayerTransform);
                    Entity.StateMachine.ChangeState(_aiVehicle.ChaseState);
                }
                else if (HasStopped)
                {
                    Entity.StateMachine.ChangeState(_aiVehicle.IdleState);
                }
            }
        }
    }
}