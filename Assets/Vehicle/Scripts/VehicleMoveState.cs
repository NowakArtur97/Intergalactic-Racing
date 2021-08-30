using NowakArtur97.IntergalacticRacing.Core;
using UnityEngine;

namespace NowakArtur97.IntergalacticRacing.StateMachine
{
    public class VehicleMoveState : State
    {
        private Vehicle _vehicle;

        public float accelerationFactor = 30.0f;
        public float maxSpeed = 20.0f;
        public float driftFactor = 0.95f;
        public float turnFactor = 3.5f;
        public float rotationAngle;
        public float velocityVsUp;
        public float dragAmount = 3;

        public VehicleMoveState(Vehicle Entity) : base(Entity)
        {
            _vehicle = Entity;
        }

        public override void PhysicsUpdate()
        {
            base.PhysicsUpdate();

            ApplyEngineForce();

            KillOrthogonalVelocity();

            ApplySteering();
        }

        private void ApplyEngineForce()
        {
            velocityVsUp = Vector2.Dot(Entity.transform.up, Entity.CoreContainer.Movement.CurrentVelocity);

            if (velocityVsUp > maxSpeed && _vehicle.MovementInput.y > 0.5f)
            {
                return;
            }

            if (velocityVsUp < -maxSpeed * 0.5f && _vehicle.MovementInput.y < 0)
            {
                return;
            }

            if (_vehicle.MovementInput.y == 0)
            {
                Entity.CoreContainer.Movement.ApplyDrag(dragAmount, 3);
            }
            else
            {
                Entity.CoreContainer.Movement.ResetDrag();
            }

            Entity.CoreContainer.Movement.ApplyForce(Entity.transform.up * _vehicle.MovementInput.y * accelerationFactor);
        }

        private void ApplySteering()
        {
            float minSpeedBeforeAllowTurningFactor = (Entity.CoreContainer.Movement.CurrentVelocity.magnitude / 8);
            minSpeedBeforeAllowTurningFactor = Mathf.Clamp01(minSpeedBeforeAllowTurningFactor);

            rotationAngle -= _vehicle.MovementInput.x * turnFactor;

            Entity.CoreContainer.Movement.MoveRotation(rotationAngle);
        }

        private void KillOrthogonalVelocity()
        {
            Vector2 forwardVelocity = Entity.transform.up
                * Vector2.Dot(Entity.CoreContainer.Movement.CurrentVelocity, Entity.transform.up);

            Vector2 rightVelocity = Entity.transform.right
                * Vector2.Dot(Entity.CoreContainer.Movement.CurrentVelocity, Entity.transform.right);

            Entity.CoreContainer.Movement.SetVelocity(forwardVelocity + rightVelocity * driftFactor);

        }

        protected bool CheckIsNotMoving() => _vehicle.MovementInput.y == 0
            && _vehicle.CoreContainer.Movement.CurrentVelocity.magnitude < 1.5f;
    }
}
