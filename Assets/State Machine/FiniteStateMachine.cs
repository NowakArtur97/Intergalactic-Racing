namespace NowakArtur97.IntergalacticRacing.StateMachine
{
    public class FiniteStateMachine
    {
        public State CurrentState { get; private set; }

        public void Initialize(State startingState) => CurrentState = startingState;

        public void ChangeState(State newState)
        {
            CurrentState.Exit();

            CurrentState = newState;

            CurrentState.Enter();
        }
    }
}