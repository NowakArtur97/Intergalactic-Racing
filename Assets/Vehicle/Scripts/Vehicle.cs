using NowakArtur97.IntergalacticRacing.Input;
using NowakArtur97.IntergalacticRacing.StateMachine;
using UnityEngine;

namespace NowakArtur97.IntergalacticRacing.Core
{
    [RequireComponent(typeof(PlayerInputController))]
    [RequireComponent(typeof(Rigidbody2D))]
    public class Vehicle : Entity
    {
        public VehicleIdleState VehicleIdleState { get; private set; }
        public VehicleMoveState VehicleMoveState { get; private set; }

        public PlayerInputController InputController { get; private set; }
        public Vector2 MovementInput { get; private set; }

        protected override void Awake()
        {
            base.Awake();

            VehicleIdleState = new VehicleIdleState(this, StateMachine, CoreContainer);
            VehicleMoveState = new VehicleMoveState(this, StateMachine, CoreContainer);

            InputController = GetComponent<PlayerInputController>();
        }

        private void Start() => StateMachine.Initialize(VehicleMoveState);

        protected override void Update()
        {
            base.Update();

            MovementInput = InputController.MovementInput;
        }
    }
}
