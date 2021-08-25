using UnityEngine;

namespace NowakArtur97.IntergalacticRacing.Core
{
    public class CoreComponent : MonoBehaviour
    {
        protected CoreContainer Core { get; private set; }

        protected virtual void Awake()
        {
            Core = transform.parent.GetComponent<CoreContainer>();

            if (Core == null) { Debug.LogError("There is no Core on the parent"); }
        }
    }
}
