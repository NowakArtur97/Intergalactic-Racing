using System.Collections.Generic;
using UnityEngine;
using System.Linq;

namespace NowakArtur97.IntergalacticRacing.Core
{
    public class CheckpointsManager : MonoBehaviour
    {
        [SerializeField] private List<Vehicle> _vehicles;

        private List<Checkpoint> _checkpoints;

        private Dictionary<Vehicle, int> _vehiclesCheckpointsProgress;
        private Dictionary<Vehicle, int> _vehiclesLapsProgress;

        private PositionsManager _positionsManager;

        // TODO: Get number of laps from Manager class (?)
        private int _numberOfLaps = 2;

        private void Awake()
        {
            _vehiclesCheckpointsProgress = _vehicles.ToDictionary(vehicle => vehicle, checkpoint => 0);
            _vehiclesLapsProgress = _vehicles.ToDictionary(vehicle => vehicle, checkpoint => 0);
        }

        private void Start()
        {
            _checkpoints = new List<Checkpoint>();

            foreach (Transform checkpointTransform in transform)
            {
                Checkpoint checkpoint = checkpointTransform.GetComponent<Checkpoint>();

                _checkpoints.Add(checkpoint);

                checkpoint.SetCheckpointsManager(this);
            }

            _positionsManager = FindObjectOfType<PositionsManager>();
        }

        public void VehicleDriveThroughCheckpoint(Checkpoint checkpoint, Vehicle vehicle)
        {
            int currentLap = _vehiclesLapsProgress[vehicle];
            int currentCheckpoint = _checkpoints.IndexOf(checkpoint);
            int nextCheckpoint = _vehiclesCheckpointsProgress[vehicle];

            if (IsFullLap(currentCheckpoint, nextCheckpoint))
            {
                _vehiclesCheckpointsProgress[vehicle] = 1;
                currentLap++;
                _vehiclesLapsProgress[vehicle] = currentLap;

                _positionsManager.UpdatePositions(vehicle);

                Debug.Log("Full Lap");

                if (HasFinished(currentLap, currentCheckpoint))
                {
                    Debug.Log("Finish");
                }
            }
            else if (IsCorrectCheckpoint(currentCheckpoint, nextCheckpoint))
            {
                Debug.Log("Correct Checkpoint");

                _vehiclesCheckpointsProgress[vehicle] = nextCheckpoint + 1;

                _positionsManager.UpdatePositions(vehicle);
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
