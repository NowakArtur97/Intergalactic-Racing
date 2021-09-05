using NowakArtur97.IntergalacticRacing.StateMachine;

namespace NowakArtur97.IntergalacticRacing.Core
{
    public class AIPlayerChaseVehicle : AIVehicle
    {
        public Vehicle_IdleState IdleState { get; private set; }
        public Vehicle_SlowDownState SlowDownState { get; private set; }
        public AIPlayerChaseVehicle_ChaseState ChaseState { get; private set; }

        protected override void Awake()
        {
            base.Awake();

            IdleState = new AIPlayerChaseVehicle_IdleState(this);
            SlowDownState = new AIPlayerChaseVehicle_SlowDownState(this);
            ChaseState = new AIPlayerChaseVehicle_ChaseState(this);
        }

        private void Start() => StateMachine.Initialize(IdleState);
    }
}
