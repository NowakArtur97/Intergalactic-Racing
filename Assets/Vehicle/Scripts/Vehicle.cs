using NowakArtur97.IntergalacticRacing.Input;
using NowakArtur97.IntergalacticRacing.StateMachine;
using UnityEngine;

namespace NowakArtur97.IntergalacticRacing.Core
{
    [RequireComponent(typeof(PlayerInputController))]
    [RequireComponent(typeof(Rigidbody2D))]
    public class Vehicle : Entity
    {
        [SerializeField] private D_Vehicle _vehicleData;
        public D_Vehicle VehicleData { get { return _vehicleData; } private set { _vehicleData = value; } }

        public VehicleIdleState VehicleIdleState { get; private set; }
        public VehicleGoStraightState VehicleGoStraightState { get; private set; }
        public VehicleTurnState VehicleTurnState { get; private set; }
        public VehicleSlowDownState VehicleSlowDownState { get; private set; }

        public PlayerInputController InputController { get; private set; }
        public WheelsTrailRendererHandler WheelsTrailRendererHandler { get; private set; }
        public WheelSmokePartcileHandler WheelSmokePartcileHandler { get; private set; }
        public Vector2 MovementInput { get; private set; }

        public VehicleChecks VehicleChecks { get; private set; }

        public float VelocityVsUp { get; private set; }
        public float VelocityVsRight { get; private set; }
        private float _rotationAngle;

        protected override void Awake()
        {
            base.Awake();

            VehicleIdleState = new VehicleIdleState(this);
            VehicleGoStraightState = new VehicleGoStraightState(this);
            VehicleTurnState = new VehicleTurnState(this);
            VehicleSlowDownState = new VehicleSlowDownState(this);

            InputController = GetComponent<PlayerInputController>();
            WheelsTrailRendererHandler = GetComponentInChildren<WheelsTrailRendererHandler>();
            WheelSmokePartcileHandler = GetComponentInChildren<WheelSmokePartcileHandler>();

            VehicleChecks = new VehicleChecks(this);
        }

        private void Start() => StateMachine.Initialize(VehicleIdleState);

        protected override void Update()
        {
            base.Update();

            MovementInput = InputController.MovementInput;
        }

        protected override void FixedUpdate()
        {
            base.FixedUpdate();

            VelocityVsUp = Vector2.Dot(transform.up, CoreContainer.Movement.CurrentVelocity);
            VelocityVsRight = Vector2.Dot(transform.right, CoreContainer.Movement.CurrentVelocity);
        }

        public void ApplyEngineForce(float accelerationFactor) => CoreContainer.Movement.ApplyForce(transform.up * MovementInput.y * accelerationFactor);

        public void ApplySteering(float turnFactor)
        {
            float minSpeedBeforeAllowTurningFactor = CoreContainer.Movement.CurrentVelocity.magnitude / _vehicleData.magnitudeDivider;
            minSpeedBeforeAllowTurningFactor = Mathf.Clamp01(minSpeedBeforeAllowTurningFactor);

            _rotationAngle -= MovementInput.x * turnFactor;

            CoreContainer.Movement.MoveRotation(_rotationAngle);
        }

        public void KillOrthogonalVelocity(float driftFactor)
        {
            Vector2 forwardVelocity = transform.up * Vector2.Dot(transform.up, CoreContainer.Movement.CurrentVelocity);
            Vector2 rightVelocity = transform.right * Vector2.Dot(CoreContainer.Movement.CurrentVelocity, transform.right);

            CoreContainer.Movement.SetVelocity(forwardVelocity + rightVelocity * driftFactor);
        }

        public bool IsBraking() => VehicleChecks.CheckIsMovingBackward() && VelocityVsUp > 0;

        public bool IsTireScreeching() => IsBraking() || Mathf.Abs(VelocityVsRight) >= _vehicleData.tireScreechingMinVelocity;
    }
}
