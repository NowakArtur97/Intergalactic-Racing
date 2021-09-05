using NowakArtur97.IntergalacticRacing.Core;
using UnityEngine;

namespace NowakArtur97.IntergalacticRacing.StateMachine
{
    public abstract class Vehicle_MoveState : VehicleState
    {
        protected bool HasForwardVelocity { get; private set; }
        protected bool HasBackwardVelocity { get; private set; }

        protected bool IsMoving { get; private set; }
        protected bool IsTurning { get; private set; }
        protected bool HasStopped { get; private set; }

        private bool _isBraking;
        private bool _isTireScreeching;

        public Vehicle_MoveState(Vehicle Entity) : base(Entity)
        {
        }

        public override void Enter()
        {
            base.Enter();

            Vehicle.WheelSmokePartcileHandler.SetEmissionRate(Vehicle.VehicleData.maxNumberOfSmokeParticles);
        }

        public override void Exit()
        {
            base.Exit();

            Vehicle.WheelSmokePartcileHandler.SetEmissionRate(0);
        }

        public override void LogicUpdate()
        {
            base.LogicUpdate();

            HasForwardVelocity = Vehicle.CoreContainer.Movement.HasForwardVelocity();
            HasBackwardVelocity = Vehicle.CoreContainer.Movement.HasBackwardVelocity();

            Vehicle.WheelSmokePartcileHandler.SetEmissionRate(_isBraking
                ? Vehicle.VehicleData.maxNumberOfSmokeParticles : Mathf.Abs(Vehicle.VelocityVsRight) * Vehicle.VehicleData.smokeParticlesEmissionRate);
            Vehicle.WheelsTrailRendererHandler.EmitTrails(_isTireScreeching);

            SoundsUpdate();
        }

        public override void PhysicsUpdate()
        {
            base.PhysicsUpdate();

            Vehicle.KillOrthogonalVelocity(Vehicle.VehicleData.driftFactor);

            Vehicle.ApplySteering(Vehicle.VehicleData.turnFactor);
        }

        public override void DoChecks()
        {
            base.DoChecks();

            IsMoving = Vehicle.VehicleChecks.CheckIsMoving();
            IsTurning = Vehicle.VehicleChecks.CheckIsTurning();
            HasStopped = Vehicle.CoreContainer.Movement.HasStopped(Vehicle.VehicleData.idleSpeed);
        }

        private void SoundsUpdate()
        {
            _isBraking = Vehicle.IsBraking();
            _isTireScreeching = Vehicle.IsTireScreeching();

            Vehicle.VehicleSoundsHandler.UpdateEngineSFX(Vehicle.CoreContainer.Movement.CurrentVelocity.magnitude);
            Vehicle.VehicleSoundsHandler.UpdateTiresScreechingSFX(Vehicle.VelocityVsRight, _isTireScreeching, _isBraking);
        }

        public bool HasNotExceededMaximumSpeed(Speed forwardSpeed, Speed backwardSpeed) =>
            !(Vehicle.VelocityVsUp > forwardSpeed.maxSpeed && HasForwardVelocity)
            && !(Vehicle.VelocityVsUp < -backwardSpeed.maxSpeed && HasBackwardVelocity);
    }
}
