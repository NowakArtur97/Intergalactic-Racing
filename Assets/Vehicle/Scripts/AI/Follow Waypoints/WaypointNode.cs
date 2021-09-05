using UnityEngine;

namespace NowakArtur97.IntergalacticRacing.Core
{
    public class WaypointNode : MonoBehaviour
    {
        [SerializeField] private WaypointNode[] _nextWaypoints;
        public WaypointNode[] NextWaypoints { get { return _nextWaypoints; } private set { _nextWaypoints = value; } }

        [SerializeField] private float _minDistanceToReach = 1.0f;
        public float MinDistanceToReach { get { return _minDistanceToReach; } private set { _minDistanceToReach = value; } }

        [SerializeField] private float _maxSpeed = 20.0f;
        public float MaxSpeed { get { return _maxSpeed; } private set { _maxSpeed = value; } }
    }
}
