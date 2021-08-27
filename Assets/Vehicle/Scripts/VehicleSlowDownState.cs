using NowakArtur97.IntergalacticRacing.Core;

namespace NowakArtur97.IntergalacticRacing.StateMachine
{
    public class VehicleSlowDownState : SlowDownState
    {
        Vehicle _vehicle;

        // TODO: Move to data file
        public float dragAmount = 3;
        public float accelerationFactor = 30.0f;
        public float driftFactor = 0.95f;
        public float turnFactor = 3.5f;

        public VehicleSlowDownState(Vehicle Entity) : base(Entity)
        {
            _vehicle = Entity;
        }

        public override void LogicUpdate()
        {
            base.LogicUpdate();

            if (!IsExitingState)
            {
                if (_vehicle.VehicleChecks.CheckIsTurning())
                {
                    Entity.StateMachine.ChangeState(_vehicle.VehicleTurnState);
                }
                else if (_vehicle.VehicleChecks.CheckIsMoving())
                {
                    Entity.StateMachine.ChangeState(_vehicle.VehicleGoStraightState);
                }
                // TODO: Move to data file
                else if (_vehicle.CoreContainer.Movement.HasStopped(1.5f))
                {
                    Entity.StateMachine.ChangeState(_vehicle.VehicleIdleState);
                }
            }
        }

        public override void PhysicsUpdate()
        {
            base.PhysicsUpdate();

            _vehicle.ApplyEngineForce(accelerationFactor);

            _vehicle.KillOrthogonalVelocity(driftFactor);

            _vehicle.ApplySteering(turnFactor);

            // TODO: Move to data file
            Entity.CoreContainer.Movement.ApplyDrag(dragAmount, 3);
        }
    }
}
