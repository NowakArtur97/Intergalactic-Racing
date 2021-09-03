using System.Collections.Generic;
using UnityEngine;
using System.Linq;

namespace NowakArtur97.IntergalacticRacing.Core
{
    public class CheckpointsManager : MonoBehaviour
    {
        [SerializeField] private List<Vehicle> _vehicles;

        private List<Checkpoint> _checkpoints;

        private Dictionary<Vehicle, int> _vehiclesProgress;

        private void Start()
        {
            _checkpoints = new List<Checkpoint>();

            foreach (Transform checkpointTransform in transform)
            {
                Checkpoint checkpoint = checkpointTransform.GetComponent<Checkpoint>();

                _checkpoints.Add(checkpoint);

                checkpoint.SetCheckpointsManager(this);
            }

            _vehiclesProgress = _vehicles.ToDictionary(vehicle => vehicle, checkpoint => 0);
        }

        public void VehicleDriveThroughCheckpoint(Checkpoint checkpoint, Vehicle vehicle)
        {
            int currentCheckpoint = _checkpoints.IndexOf(checkpoint);
            int nextCheckpoint = _vehiclesProgress[vehicle];

            if (nextCheckpoint == currentCheckpoint)
            {
                Debug.Log("Correct");
                _vehiclesProgress[vehicle] = nextCheckpoint + 1;
            }
            else
            {
                Debug.Log("Wrong");
            }
        }
    }
}
