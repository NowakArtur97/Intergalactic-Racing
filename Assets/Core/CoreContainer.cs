using NowakArtur97.IntergalacticRacing.Util;
using UnityEngine;

namespace NowakArtur97.IntergalacticRacing.Core
{
    public class CoreContainer : MonoBehaviour
    {
        private Movement _movement;

        public Movement Movement
        {
            get => GenericNotImplementedError<Movement>.TryGet(_movement, transform.parent.name);
            private set => _movement = value;
        }

        private void Awake() => Movement = GetComponentInChildren<Movement>();

        public void LogicUpdate() => Movement.LogicUpdate();
    }
}
