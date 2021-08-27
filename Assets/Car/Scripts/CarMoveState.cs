using NowakArtur97.IntergalacticRacing.Core;
using UnityEngine;

namespace NowakArtur97.IntergalacticRacing.StateMachine
{
    public class CarMoveState : MoveState
    {
        // TODO: CarMoveState: Refactor
        private Car _car;

        // TODO: CarMoveState: Move to data file(?)
        public float accelerationFactor = 30.0f;

        // TODO: CarMoveState: Move to Drift State
        // TODO: CarMoveState: Move to data file(?)
        public float driftFactor = 0.95f;
        public float turnFactor = 3.5f;
        public float rotationAngle;

        public CarMoveState(Car Entity, FiniteStateMachine StateMachine, CoreContainer CoreContainer)
           : base(Entity, StateMachine, CoreContainer)
        {
            _car = Entity;
        }

        public override void LogicUpdate()
        {
            base.LogicUpdate();

            if (IsNotMoving)
            {
                Entity.StateMachine.ChangeState(_car.CarIdleState);
            }
        }

        public override void PhysicsUpdate()
        {
            base.PhysicsUpdate();

            ApplyEngineForce();

            KillOrthogonalVelocity();

            ApplySteering();
        }

        private void ApplyEngineForce() => Entity.CoreContainer.Movement.ApplyForce(Entity.transform.up * _car.MovementInput.y * accelerationFactor, ForceMode2D.Force);

        private void ApplySteering()
        {
            // TODO: Refactor
            float minSpeedBeforeAllowTurningFactor = (Entity.CoreContainer.Movement.CurrentVelocity.magnitude / 8);
            minSpeedBeforeAllowTurningFactor = Mathf.Clamp01(minSpeedBeforeAllowTurningFactor);

            rotationAngle -= _car.MovementInput.x * turnFactor;

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

        // TODO: CarIdleState: Refactor with parent
        // TODO: Refactor
        protected override bool CheckIsNotMoving() => _car.MovementInput.y == 0
            && _car.CoreContainer.Movement.CurrentVelocity.magnitude < 1.5f;
    }
}
