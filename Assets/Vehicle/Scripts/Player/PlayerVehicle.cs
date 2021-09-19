using NowakArtur97.IntergalacticRacing.Input;
using NowakArtur97.IntergalacticRacing.StateMachine;
using System;
using UnityEngine;

namespace NowakArtur97.IntergalacticRacing.Core
{
    [RequireComponent(typeof(PlayerInputController))]
    public class PlayerVehicle : Vehicle
    {
        public event Action PlayerFinished;
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
            FindObjectOfType<CheckpointsManager>().FinishEvent += OnFinish; // TODO: Unsubscibe (?)
        }

        protected override void Update()
        {
            base.Update();

            MovementInput = _stopMoving ? Vector2.zero : InputController.MovementInput;
        }

        // TODO: PlayerVehicle: Auto drive instead of stopping
        private void OnFinish(Vehicle vehicle)
        {
            if (vehicle == this)
            {
                _stopMoving = true;
                PlayerFinished?.Invoke();
            }
        }

        public override bool IsBraking() => base.IsBraking() && VehicleChecks.CheckIsMovingBackward();
    }
}
