using System.Collections.Generic;
using UnityEngine;
using System.Linq;

namespace NowakArtur97.IntergalacticRacing.Core
{
    public class CheckpointsManager : MonoBehaviour
    {
        [SerializeField] private List<Vehicle> _vehicles;

        private List<Checkpoint> _checkpoints;

        private Dictionary<Vehicle, int> _vehicleCheckpointsProgress;
        private Dictionary<Vehicle, int> _vehicleLapsProgress;

        // TODO: Get number of laps from Manager class (?)
        private int _numberOfLaps = 2;

        private void Start()
        {
            _checkpoints = new List<Checkpoint>();

            foreach (Transform checkpointTransform in transform)
            {
                Checkpoint checkpoint = checkpointTransform.GetComponent<Checkpoint>();

                _checkpoints.Add(checkpoint);

                checkpoint.SetCheckpointsManager(this);
            }

            _vehicleCheckpointsProgress = _vehicles.ToDictionary(vehicle => vehicle, checkpoint => 0);
            _vehicleLapsProgress = _vehicles.ToDictionary(vehicle => vehicle, checkpoint => 0);
        }

        public void VehicleDriveThroughCheckpoint(Checkpoint checkpoint, Vehicle vehicle)
        {
            int currentLap = _vehicleLapsProgress[vehicle];
            int currentCheckpoint = _checkpoints.IndexOf(checkpoint);
            int nextCheckpoint = _vehicleCheckpointsProgress[vehicle];

            if (IsFullLap(currentCheckpoint, nextCheckpoint))
            {
                _vehicleCheckpointsProgress[vehicle] = 1;
                currentLap++;
                _vehicleLapsProgress[vehicle] = currentLap;

                Debug.Log("Full Lap");

                if (HasFinished(currentLap, currentCheckpoint))
                {
                    Debug.Log("Finish");
                }
            }
            else if (IsCorrectCheckpoint(currentCheckpoint, nextCheckpoint))
            {
                Debug.Log("Correct Checkpoint");
                _vehicleCheckpointsProgress[vehicle] = nextCheckpoint + 1;
            }
            else
            {
                Debug.Log("Wrong Checkpoint");
            }
        }

        private bool IsCorrectCheckpoint(int currentCheckpoint, int nextCheckpoint) => nextCheckpoint == currentCheckpoint;

        private bool IsFullLap(int currentCheckpoint, int nextCheckpoint) => currentCheckpoint == 0
            && nextCheckpoint == _checkpoints.Count;

        private bool HasFinished(int currentLap, int currentCheckpoint) => currentLap == _numberOfLaps;
    }
}
