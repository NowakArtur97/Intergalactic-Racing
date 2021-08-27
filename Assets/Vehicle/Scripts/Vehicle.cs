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
        // TODO: REMOVE
        public VehicleMoveState VehicleMoveState { get; private set; }
        public VehicleGoStraightState VehicleGoStraightState { get; private set; }
        public VehicleTurnState VehicleTurnState { get; private set; }
        public VehicleSlowDownState VehicleSlowDownState { get; private set; }

        public PlayerInputController InputController { get; private set; }
        public Vector2 MovementInput { get; private set; }

        public VehicleChecks VehicleChecks { get; private set; }

        public float VelocityVsUp { get; private set; }
        public float RotationAngle { get; private set; }

        protected override void Awake()
        {
            base.Awake();

            VehicleIdleState = new VehicleIdleState(this);
            // TODO: REMOVE
            VehicleMoveState = new VehicleMoveState(this);
            VehicleGoStraightState = new VehicleGoStraightState(this);
            VehicleTurnState = new VehicleTurnState(this);
            VehicleSlowDownState = new VehicleSlowDownState(this);

            InputController = GetComponent<PlayerInputController>();

            VehicleChecks = new VehicleChecks(this);
        }

        private void Start() => StateMachine.Initialize(VehicleIdleState);
        // TODO: REMOVE
        //private void Start() => StateMachine.Initialize(VehicleMoveState);

        protected override void Update()
        {
            base.Update();

            MovementInput = InputController.MovementInput;
        }

        protected override void FixedUpdate()
        {
            base.FixedUpdate();

            VelocityVsUp = Vector2.Dot(transform.up, CoreContainer.Movement.CurrentVelocity);
        }

        public void ApplyEngineForce(float accelerationFactor) => CoreContainer.Movement.ApplyForce(transform.up * MovementInput.y * accelerationFactor);

        public void ApplySteering(float turnFactor)
        {
            // TODO: Refactor
            float minSpeedBeforeAllowTurningFactor = CoreContainer.Movement.CurrentVelocity.magnitude / 8;
            minSpeedBeforeAllowTurningFactor = Mathf.Clamp01(minSpeedBeforeAllowTurningFactor);

            RotationAngle -= MovementInput.x * turnFactor;

            CoreContainer.Movement.MoveRotation(RotationAngle);
        }

        public void KillOrthogonalVelocity(float driftFactor)
        {
            Vector2 forwardVelocity = transform.up * Vector2.Dot(CoreContainer.Movement.CurrentVelocity, transform.up);

            Vector2 rightVelocity = transform.right * Vector2.Dot(CoreContainer.Movement.CurrentVelocity, transform.right);

            CoreContainer.Movement.SetVelocity(forwardVelocity + rightVelocity * driftFactor);
        }
    }
}