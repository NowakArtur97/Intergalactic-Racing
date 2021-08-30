using UnityEngine;

namespace NowakArtur97.IntergalacticRacing.Core
{
    [RequireComponent(typeof(TrailRenderer))]
    public class WheelTrailRendererHandler : MonoBehaviour
    {
        private Vehicle _vehicle;

        private TrailRenderer _trailRenderer;

        private void Awake()
        {
            _vehicle = GetComponentInParent<Vehicle>();

            _trailRenderer = GetComponent<TrailRenderer>();

            _trailRenderer.emitting = false;
        }

        private void Update() => _trailRenderer.emitting = _vehicle.IsTireScreeching();
    }
}
