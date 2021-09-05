using NowakArtur97.IntergalacticRacing.Core;

namespace NowakArtur97.IntergalacticRacing.StateMachine
{
    public abstract class VehicleState : State
    {
        protected readonly Vehicle Vehicle;

        public VehicleState(Vehicle Entity) : base(Entity)
        {
            Vehicle = Entity;
        }
    }
}
