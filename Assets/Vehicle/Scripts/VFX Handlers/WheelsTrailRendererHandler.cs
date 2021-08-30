using UnityEngine;
using System.Linq;

namespace NowakArtur97.IntergalacticRacing.Core
{
    public class WheelsTrailRendererHandler : MonoBehaviour
    {
        private TrailRenderer[] _trailRenderers;

        private void Awake()
        {
            _trailRenderers = GetComponentsInChildren<TrailRenderer>();

            EmitTrails(false);
        }

        public void EmitTrails(bool shouldEmit) => _trailRenderers.ToList().ForEach(trail => trail.emitting = shouldEmit);
    }
}
