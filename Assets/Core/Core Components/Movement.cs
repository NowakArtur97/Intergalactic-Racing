using UnityEngine;

namespace NowakArtur97.IntergalacticRacing.Core
{
    public class Movement : CoreComponent
    {
        private Rigidbody2D _myRigidbody;
        private Vector2 _workspace;

        public Vector2 CurrentVelocity { get; private set; }

        protected override void Awake()
        {
            base.Awake();

            _myRigidbody = GetComponentInParent<Rigidbody2D>();
        }

        public void LogicUpdate() => CurrentVelocity = _myRigidbody.velocity;

        // TODO: USE
        private void SetFinalVelocity()
        {
            _myRigidbody.velocity = _workspace;
            CurrentVelocity = _workspace;
        }
    }
}

