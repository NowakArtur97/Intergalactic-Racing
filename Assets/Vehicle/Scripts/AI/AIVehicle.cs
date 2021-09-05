using NowakArtur97.IntergalacticRacing.StateMachine;

namespace NowakArtur97.IntergalacticRacing.Core
{
    public abstract class AIVehicle : Vehicle
    {
        public VehicleIdleState AIVehicleIdleState { get; private set; }
        public AIVehicleChaseState AIVehicleChaseState { get; private set; }

        protected override void Awake()
        {
            base.Awake();

            AIVehicleIdleState = new AIVehicleIdleState(this);
            AIVehicleChaseState = new AIVehicleChaseState(this);
        }

        private void Start() => StateMachine.Initialize(AIVehicleIdleState);
    }
}
