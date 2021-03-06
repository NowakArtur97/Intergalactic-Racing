using UnityEngine;

namespace NowakArtur97.IntergalacticRacing.Core
{
    public class Movement : CoreComponent
    {
        private Rigidbody2D _myRigidbody;
        private Vector2 _workspace;

        public Vector2 CurrentVelocity { get; private set; }

        private float _defaultDrag;
        private float _defaultAngularDrag;

        protected override void Awake()
        {
            base.Awake();

            _myRigidbody = GetComponentInParent<Rigidbody2D>();

            _defaultDrag = _myRigidbody.drag;
            _defaultAngularDrag = _myRigidbody.angularDrag;
        }

        public void LogicUpdate() => CurrentVelocity = _myRigidbody.velocity;

        public void SetVelocityZero()
        {
            _workspace = Vector2.zero;
            SetFinalVelocity();
        }

        public void SetVelocity(Vector2 velocity)
        {
            _workspace = velocity;
            SetFinalVelocity();
        }

        public void SetVelocityFromForce(Vector2 force)
        {
            _workspace = force / _myRigidbody.mass * Time.fixedDeltaTime;
            SetFinalVelocity();
        }

        private void SetFinalVelocity()
        {
            _myRigidbody.velocity = _workspace;
            CurrentVelocity = _workspace;
        }

        public bool HasStopped(float magnitude) => CurrentVelocity.magnitude < magnitude;

        public bool IsFasterThan(float maxSpeed) => CurrentVelocity.magnitude > maxSpeed;

        public bool HasForwardVelocity() => CurrentVelocity.y > 0;

        public bool HasBackwardVelocity() => CurrentVelocity.y < 0;

        public void ApplyDrag(float dragAmount, float time) =>
            _myRigidbody.drag = Mathf.Lerp(_myRigidbody.drag, dragAmount, Time.deltaTime * time);

        public void ApplyAngularDrag(float dragAmount, float time) =>
           _myRigidbody.angularDrag = Mathf.Lerp(_myRigidbody.drag, dragAmount, Time.deltaTime * time);

        public void ResetDrag()
        {
            _myRigidbody.drag = _defaultDrag;
            _myRigidbody.angularDrag = _defaultAngularDrag;
        }

        public void ApplyForce(Vector2 force, ForceMode2D forceMode = ForceMode2D.Force) => _myRigidbody.AddForce(force, forceMode);

        public void MoveRotation(float rotationAngle) => _myRigidbody.MoveRotation(rotationAngle);
    }
}