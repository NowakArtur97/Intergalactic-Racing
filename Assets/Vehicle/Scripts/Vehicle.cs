using UnityEngine;

namespace NowakArtur97.IntergalacticRacing.Core
{
    [RequireComponent(typeof(Rigidbody2D))]
    public abstract class Vehicle : Entity
    {
        [SerializeField] private D_Vehicle _vehicleData;
        public D_Vehicle VehicleData { get { return _vehicleData; } private set { _vehicleData = value; } }

        public WheelsTrailRendererHandler WheelsTrailRendererHandler { get; private set; }
        public WheelSmokePartcileHandler WheelSmokePartcileHandler { get; private set; }
        public VehicleSoundsHandler VehicleSoundsHandler { get; private set; }

        public VehicleChecks VehicleChecks { get; private set; }

        [HideInInspector] public Vector2 MovementInput;
        public float VelocityVsUp { get; private set; }
        public float VelocityVsRight { get; private set; }
        private float _rotationAngle;

        protected override void Awake()
        {
            base.Awake();

            WheelsTrailRendererHandler = GetComponentInChildren<WheelsTrailRendererHandler>();
            WheelSmokePartcileHandler = GetComponentInChildren<WheelSmokePartcileHandler>();
            VehicleSoundsHandler = GetComponentInChildren<VehicleSoundsHandler>();

            VehicleChecks = new VehicleChecks(this);
        }

        protected override void FixedUpdate()
        {
            base.FixedUpdate();

            VelocityVsUp = Vector2.Dot(transform.up, CoreContainer.Movement.CurrentVelocity);
            VelocityVsRight = Vector2.Dot(transform.right, CoreContainer.Movement.CurrentVelocity);
        }

        public void ApplyEngineForce(float accelerationFactor) =>
            CoreContainer.Movement.ApplyForce(transform.up * MovementInput.y * accelerationFactor);

        public void ApplySteering(float turnFactor)
        {
            _rotationAngle = transform.localRotation.eulerAngles.z - 360; // correction for collisions

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

        public virtual bool IsBraking() => VelocityVsUp > 0;

        public bool IsTireScreeching() => IsBraking() || Mathf.Abs(VelocityVsRight) >= _vehicleData.tireScreechingMinVelocity;
    }
}
