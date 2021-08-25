using NowakArtur97.IntergalacticRacing.Input;
using NowakArtur97.IntergalacticRacing.StateMachine;
using UnityEngine;

namespace NowakArtur97.IntergalacticRacing.Core
{
    [RequireComponent(typeof(PlayerInputController))]
    [RequireComponent(typeof(Rigidbody2D))]
    public class Car : Entity
    {
        protected Vector2 MovementInput { get; private set; }

        public PlayerInputController InputController { get; private set; }

        public CarIdleState CarIdleState { get; private set; }
        public CarMoveState CarMoveState { get; private set; }

        protected override void Awake()
        {
            base.Awake();

            CarIdleState = new CarIdleState(this, StateMachine, CoreContainer);
            CarMoveState = new CarMoveState(this, StateMachine, CoreContainer);

            StateMachine.Initialize(CarIdleState);

            InputController = GetComponent<PlayerInputController>();
        }

        protected override void Update()
        {
            base.Update();

            MovementInput = InputController.MovementInput;
        }
    }
}
