using System;
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

        public void SetVelocityZero()
        {
            _workspace = Vector2.zero;
            SetFinalVelocity();
        }

        private void SetFinalVelocity()
        {
            _myRigidbody.velocity = _workspace;
            CurrentVelocity = _workspace;
        }

        public void ApplyForce(Vector2 force, ForceMode2D forceMode) => _myRigidbody.AddForce(force, forceMode);

        public void MoveRotation(float rotationAngle) => _myRigidbody.MoveRotation(rotationAngle);
    }
}