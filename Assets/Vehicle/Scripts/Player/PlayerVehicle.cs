using NowakArtur97.IntergalacticRacing.Input;
using NowakArtur97.IntergalacticRacing.StateMachine;

namespace NowakArtur97.IntergalacticRacing.Core
{
    public class PlayerVehicle : Vehicle
    {
        public VehicleIdleState VehicleIdleState { get; private set; }
        public VehicleGoStraightState VehicleGoStraightState { get; private set; }
        public VehicleTurnState VehicleTurnState { get; private set; }
        public VehicleSlowDownState VehicleSlowDownState { get; private set; }

        public PlayerInputController InputController { get; private set; }

        protected override void Awake()
        {
            base.Awake();

            VehicleIdleState = new PlayerVehicleIdleState(this);
            VehicleGoStraightState = new PlayerVehicleGoStraightState(this);
            VehicleTurnState = new PlayerVehicleTurnState(this);
            VehicleSlowDownState = new PlayerVehicleSlowDownState(this);

            InputController = GetComponent<PlayerInputController>();
        }

        private void Start() => StateMachine.Initialize(VehicleIdleState);

        protected override void Update()
        {
            base.Update();

            MovementInput = InputController.MovementInput;
        }
    }
}
