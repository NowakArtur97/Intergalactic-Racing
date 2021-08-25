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

            ApplySteering();
        }

        private void ApplyEngineForce()
        {
            Vector2 engineForceVector = Entity.transform.up * _car.MovementInput.y * accelerationFactor;

            Entity.CoreContainer.Movement.ApplyForce(engineForceVector, ForceMode2D.Force);
        }

        private void ApplySteering()
        {
            rotationAngle -= _car.MovementInput.x * turnFactor;

            Entity.CoreContainer.Movement.MoveRotation(rotationAngle);
        }

        // TODO: CarIdleState: Refactor with parent
        protected override bool CheckIsNotMoving() => _car.MovementInput.y == 0;
    }
}
