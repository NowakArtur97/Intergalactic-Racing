using NowakArtur97.IntergalacticRacing.Input;
using NowakArtur97.IntergalacticRacing.StateMachine;
using UnityEngine;

namespace NowakArtur97.IntergalacticRacing.Core
{
    [RequireComponent(typeof(PlayerInputController))]
    public class PlayerVehicle : Vehicle
    {
        public VehicleIdleState PlayerVehicleIdleState { get; private set; }
        public VehicleGoStraightState PlayerVehicleGoStraightState { get; private set; }
        public VehicleTurnState PlayerVehicleTurnState { get; private set; }
        public VehicleSlowDownState PlayerVehicleSlowDownState { get; private set; }

        public PlayerInputController InputController { get; private set; }

        protected override void Awake()
        {
            base.Awake();

            PlayerVehicleIdleState = new PlayerVehicleIdleState(this);
            PlayerVehicleGoStraightState = new PlayerVehicleGoStraightState(this);
            PlayerVehicleTurnState = new PlayerVehicleTurnState(this);
            PlayerVehicleSlowDownState = new PlayerVehicleSlowDownState(this);

            InputController = GetComponent<PlayerInputController>();
        }

        private void Start() => StateMachine.Initialize(PlayerVehicleIdleState);

        protected override void Update()
        {
            base.Update();

            MovementInput = InputController.MovementInput;
        }
    }
}
