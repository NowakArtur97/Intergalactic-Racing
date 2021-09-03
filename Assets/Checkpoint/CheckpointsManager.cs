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
            _vehicleLapsProgress = _vehicles.ToDictionary(vehicle => vehicle, checkpoint => -1);
        }

        public void VehicleDriveThroughCheckpoint(Checkpoint checkpoint, Vehicle vehicle)
        {
            int currentLap = _vehicleLapsProgress[vehicle];
            int currentCheckpoint = _checkpoints.IndexOf(checkpoint);
            int nextCheckpoint = _vehicleCheckpointsProgress[vehicle];

            if (IsCorrectCheckpoint(currentCheckpoint, nextCheckpoint))
            {
                Debug.Log("Correct Checkpoint");
                if (IsFullLap(currentCheckpoint))
                {
                    _vehicleCheckpointsProgress[vehicle] = 0;
                    _vehicleLapsProgress[vehicle] = currentLap + 1;

                    Debug.Log("Full Lap");
                }
                else
                {
                    _vehicleCheckpointsProgress[vehicle] = _vehicleCheckpointsProgress[vehicle] + 1;
                }

                if (HasFinished(currentLap, currentCheckpoint))
                {
                    Debug.Log("Finish");
                }
            }
            else
            {
                Debug.Log("Wrong Checkpoint");
            }
        }

        private bool IsCorrectCheckpoint(int currentCheckpoint, int nextCheckpoint) => nextCheckpoint == currentCheckpoint;

        private bool IsFullLap(int checkpoint) => checkpoint + 1 == _checkpoints.Count;

        private bool HasFinished(int currentLap, int currentCheckpoint) => currentCheckpoint == 0 && currentLap == _numberOfLaps;
    }
}
