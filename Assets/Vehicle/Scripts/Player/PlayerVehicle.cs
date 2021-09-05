using NowakArtur97.IntergalacticRacing.Input;
using NowakArtur97.IntergalacticRacing.StateMachine;
using UnityEngine;

namespace NowakArtur97.IntergalacticRacing.Core
{
    [RequireComponent(typeof(PlayerInputController))]
    public class PlayerVehicle : Vehicle
    {
        public Vehicle_IdleState IdleState { get; private set; }
        public Vehicle_GoStraightState GoStraightState { get; private set; }
        public Vehicle_TurnState TurnState { get; private set; }
        public Vehicle_SlowDownState SlowDownState { get; private set; }

        public PlayerInputController InputController { get; private set; }

        protected override void Awake()
        {
            base.Awake();

            IdleState = new PlayerVehicle_IdleState(this);
            GoStraightState = new PlayerVehicle_GoStraightState(this);
            TurnState = new PlayerVehicle_TurnState(this);
            SlowDownState = new PlayerVehicle_SlowDownState(this);

            InputController = GetComponent<PlayerInputController>();
        }

        private void Start() => StateMachine.Initialize(IdleState);

        protected override void Update()
        {
            base.Update();

            MovementInput = InputController.MovementInput;
        }

        public override bool IsBraking() => base.IsBraking() && VehicleChecks.CheckIsMovingBackward();
    }
}
