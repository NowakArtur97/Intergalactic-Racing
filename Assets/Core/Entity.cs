using NowakArtur97.IntergalacticRacing.StateMachine;
using UnityEngine;

namespace NowakArtur97.IntergalacticRacing.Core
{
    public abstract class Entity : MonoBehaviour
    {
        public CoreContainer CoreContainer { get; private set; }
        public FiniteStateMachine StateMachine { get; private set; }

        protected virtual void Awake()
        {
            CoreContainer = GetComponentInChildren<CoreContainer>();

            StateMachine = new FiniteStateMachine();
        }

        protected virtual void Update()
        {
            CoreContainer.LogicUpdate();

            StateMachine.CurrentState.LogicUpdate();
        }

        protected virtual void FixedUpdate() => StateMachine.CurrentState.PhysicsUpdate();
    }
}