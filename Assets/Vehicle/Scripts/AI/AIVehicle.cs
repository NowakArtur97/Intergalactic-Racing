using NowakArtur97.IntergalacticRacing.StateMachine;

namespace NowakArtur97.IntergalacticRacing.Core
{
    public abstract class AIVehicle : Vehicle
    {
        public VehicleIdleState AIVehicleIdleState { get; private set; }

        protected override void Awake()
        {
            base.Awake();

            AIVehicleIdleState = new AIVehicleIdleState(this);
        }

        private void Start() => StateMachine.Initialize(AIVehicleIdleState);
    }
}
