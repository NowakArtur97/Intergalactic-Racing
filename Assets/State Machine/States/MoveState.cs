using NowakArtur97.IntergalacticRacing.Core;

namespace NowakArtur97.IntergalacticRacing.StateMachine
{
    public abstract class MoveState : State
    {
        public MoveState(Entity Entity) : base(Entity)
        { }
    }
}