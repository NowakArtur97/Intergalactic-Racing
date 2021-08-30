using NowakArtur97.IntergalacticRacing.Core;

namespace NowakArtur97.IntergalacticRacing.StateMachine
{
    public class VehicleSlowDownState : SlowDownState
    {
        private Vehicle _vehicle;

        public VehicleSlowDownState(Vehicle Entity) : base(Entity)
        {
            _vehicle = Entity;
        }

        public override void Exit()
        {
            base.Exit();

            Entity.CoreContainer.Movement.ResetDrag();
        }

        public override void LogicUpdate()
        {
            base.LogicUpdate();

            if (!IsExitingState)
            {
                if (_vehicle.CoreContainer.Movement.HasStopped(_vehicle.VehicleData.idleSpeed))
                {
                    Entity.StateMachine.ChangeState(_vehicle.VehicleIdleState);
                }
                else if (_vehicle.VehicleChecks.CheckIsTurning())
                {
                    Entity.StateMachine.ChangeState(_vehicle.VehicleTurnState);
                }
                else if (_vehicle.VehicleChecks.CheckIsMoving())
                {
                    Entity.StateMachine.ChangeState(_vehicle.VehicleGoStraightState);
                }
            }
        }

        public override void PhysicsUpdate()
        {
            base.PhysicsUpdate();

            _vehicle.ApplyEngineForce(_vehicle.VehicleData.forwardAccelerationFactor);

            _vehicle.KillOrthogonalVelocity(_vehicle.VehicleData.driftFactor);

            _vehicle.ApplySteering(_vehicle.VehicleData.turnFactor);

            Entity.CoreContainer.Movement.ApplyDrag(_vehicle.VehicleData.dragAmount, _vehicle.VehicleData.dragTime);
        }
    }
}
