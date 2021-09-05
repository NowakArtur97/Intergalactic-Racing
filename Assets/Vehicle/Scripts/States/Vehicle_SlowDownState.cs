using NowakArtur97.IntergalacticRacing.Core;
using NowakArtur97.IntergalacticRacing.Util;
using UnityEngine;

namespace NowakArtur97.IntergalacticRacing.StateMachine
{
    public abstract class Vehicle_SlowDownState : Vehicle_MoveState
    {
        protected Transform PlayerTransform { get; private set; }

        public Vehicle_SlowDownState(Vehicle Entity) : base(Entity)
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

            Entity.CoreContainer.Movement.ApplyDrag(Vehicle.VehicleData.slowDownDragAmount, Vehicle.VehicleData.slowDownDragTime);
        }

        public override void DoChecks()
        {
            base.DoChecks();

            PlayerTransform = GameObject.FindGameObjectWithTag(GameTags.PLAYER_TAG)?.transform;
        }
    }
}
