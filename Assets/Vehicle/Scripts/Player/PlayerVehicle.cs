using System;
using NowakArtur97.IntergalacticRacing.Input;
using NowakArtur97.IntergalacticRacing.StateMachine;
using UnityEngine;

namespace NowakArtur97.IntergalacticRacing.Core
{
    [RequireComponent(typeof(PlayerInputController))]
    public class PlayerVehicle : Vehicle
    {
        private bool _stopMoving;

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

            _stopMoving = false;
        }

        private void Start()
        {
            StateMachine.Initialize(IdleState);

            FindObjectOfType<CheckpointsManager>().FinishEvent += OnPlayerFinish;
        }

        private void OnPlayerFinish(Vehicle vehicle)
        {
            if (vehicle == this)
            {
                _stopMoving = true;
            }
        }

        protected override void Update()
        {
            base.Update();

            MovementInput = _stopMoving ? Vector2.zero : InputController.MovementInput;
        }

        public override bool IsBraking() => base.IsBraking() && VehicleChecks.CheckIsMovingBackward();
    }
}
