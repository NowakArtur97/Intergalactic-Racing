using NowakArtur97.IntergalacticRacing.Core;
using NowakArtur97.IntergalacticRacing.Util;
using UnityEngine;

namespace NowakArtur97.IntergalacticRacing.StateMachine
{
    public abstract class Vehicle_IdleState : VehicleState
    {
        protected bool IsMoving { get; private set; }
        protected Transform PlayerTransform { get; private set; }

        public Vehicle_IdleState(Vehicle Entity) : base(Entity)
        {
        }

        public override void Enter()
        {
            base.Enter();

            Entity.CoreContainer.Movement.SetVelocityZero();
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

        public override void DoChecks()
        {
            base.DoChecks();

            IsMoving = Vehicle.VehicleChecks.CheckIsMoving();
            PlayerTransform = GameObject.FindGameObjectWithTag(GameTags.PLAYER_TAG)?.transform;
        }
    }
}