using UnityEngine;

namespace NowakArtur97.IntergalacticRacing.Core
{
    public class WaypointNode : MonoBehaviour
    {
        [SerializeField] private WaypointNode[] _nextWaypoints;
        public WaypointNode[] NextWaypoints { get { return _nextWaypoints; } private set { _nextWaypoints = value; } }

        [SerializeField] private float minDistanceToReach = 1.0f;
        public float MinDistanceToReach { get { return minDistanceToReach; } private set { minDistanceToReach = value; } }
    }
}
