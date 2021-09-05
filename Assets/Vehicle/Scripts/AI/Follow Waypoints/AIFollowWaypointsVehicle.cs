using NowakArtur97.IntergalacticRacing.StateMachine;
using UnityEngine;

namespace NowakArtur97.IntergalacticRacing.Core
{
    public class AIFollowWaypointsVehicle : AIVehicle
    {
        public AIFollowWaypointsVehicle_FollowWaypointState FollowWaypointState { get; private set; }

        [SerializeField] private WaypointNode[] _waypoints;
        public WaypointNode[] Waypoints { get { return _waypoints; } private set { _waypoints = value; } }

        protected override void Awake()
        {
            base.Awake();

            FollowWaypointState = new AIFollowWaypointsVehicle_FollowWaypointState(this);
        }

        private void Start() => StateMachine.Initialize(FollowWaypointState);
    }
}
