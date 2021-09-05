using NowakArtur97.IntergalacticRacing.Core;

namespace NowakArtur97.IntergalacticRacing.StateMachine
{
    public abstract class VehicleSlowDownState : VehicleMoveState
    {
        public VehicleSlowDownState(Vehicle Entity) : base(Entity)
        {
        }

        public override void Exit()
        {
            base.Exit();

            Entity.CoreContainer.Movement.ResetDrag();
        }

        public override void PhysicsUpdate()
        {
            base.PhysicsUpdate();

            Entity.CoreContainer.Movement.ApplyDrag(Vehicle.VehicleData.dragAmount, Vehicle.VehicleData.dragTime);
        }
    }
}
