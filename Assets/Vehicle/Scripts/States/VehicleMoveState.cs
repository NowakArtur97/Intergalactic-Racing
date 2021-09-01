using NowakArtur97.IntergalacticRacing.Core;
using UnityEngine;

namespace NowakArtur97.IntergalacticRacing.StateMachine
{
    public abstract class VehicleMoveState : State
    {
        private Vehicle _vehicle;

        protected bool HasForwardVelocity;
        protected bool HasBackwardVelocity;

        private bool _isBraking;
        private bool _isTireScreeching;

        public VehicleMoveState(Vehicle Entity) : base(Entity)
        {
            _vehicle = Entity;
        }

        public override void Enter()
        {
            base.Enter();

            _vehicle.WheelSmokePartcileHandler.SetEmissionRate(_vehicle.VehicleData.maxNumberOfSmokeParticles);
        }

        public override void Exit()
        {
            base.Exit();

            _vehicle.WheelSmokePartcileHandler.SetEmissionRate(0);
        }

        public override void LogicUpdate()
        {
            base.LogicUpdate();

            HasForwardVelocity = _vehicle.CoreContainer.Movement.HasForwardVelocity();
            HasBackwardVelocity = _vehicle.CoreContainer.Movement.HasBackwardVelocity();

            _vehicle.WheelSmokePartcileHandler.SetEmissionRate(_isBraking
                ? _vehicle.VehicleData.maxNumberOfSmokeParticles : Mathf.Abs(_vehicle.VelocityVsRight) * _vehicle.VehicleData.smokeParticlesEmissionRate);
            _vehicle.WheelsTrailRendererHandler.EmitTrails(_isTireScreeching);

            SoundsUpdate();
        }

        private void SoundsUpdate()
        {
            _isBraking = _vehicle.IsBraking();
            _isTireScreeching = _vehicle.IsTireScreeching();

            _vehicle.VehicleSoundsHandler.UpdateEngineSFX(_vehicle.CoreContainer.Movement.CurrentVelocity.magnitude);
            _vehicle.VehicleSoundsHandler.UpdateTiresScreechingSFX(_vehicle.VelocityVsRight, _isTireScreeching, _isBraking);
        }

        public override void PhysicsUpdate()
        {
            base.PhysicsUpdate();

            _vehicle.KillOrthogonalVelocity(_vehicle.VehicleData.driftFactor);

            _vehicle.ApplySteering(_vehicle.VehicleData.turnFactor);
        }

        public bool HasNotExceededMaximumSpeed(Speed forwardSpeed, Speed backwardSpeed) =>
            !(_vehicle.VelocityVsUp > forwardSpeed.maxSpeed && HasForwardVelocity)
            && !(_vehicle.VelocityVsUp < -backwardSpeed.maxSpeed && HasBackwardVelocity);
    }
}
