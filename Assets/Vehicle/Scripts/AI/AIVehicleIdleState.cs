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
    }
}
