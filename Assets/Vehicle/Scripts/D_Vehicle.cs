using UnityEngine;

namespace NowakArtur97.IntergalacticRacing.Core
{
    [CreateAssetMenu(fileName = "D_", menuName = "Data/Vehicle")]
    public class D_Vehicle : ScriptableObject
    {
        public Speed forwardSpeed;

        public Speed backwardSpeed;

        public Speed turningForwardSpeed;

        public Speed turningBackwardSpeed;

        public float driftFactor = 0.95f;
        public float turnFactor = 3.5f;
        public float magnitudeDivider = 8.0f;

        public float idleDragAmount = 2.0f;
        public float idleDragTime = 2.0f;
        public float slowDownDragAmount = 3.0f;
        public float slowDownDragTime = 3.0f;

        public float idleSpeed = 1.5f;

        public float tireScreechingMinVelocity = 4.0f;

        public float maxNumberOfSmokeParticles = 100.0f;
        public float smokeParticlesEmissionRate = 10.0f;
    }
}
