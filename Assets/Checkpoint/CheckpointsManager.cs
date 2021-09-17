using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;

namespace NowakArtur97.IntergalacticRacing.Core
{
    public class CheckpointsManager : MonoBehaviour
    {
        public event Action<Vehicle> PositionEvent;
        public event Action<Vehicle> LapEvent;
        public event Action<Vehicle> FinishEvent;

        private List<Vehicle> _vehicles;

        private List<Checkpoint> _checkpoints;

        private Dictionary<Vehicle, int> _vehiclesCheckpointsProgress;
        private Dictionary<Vehicle, int> _vehiclesLapsProgress;

        private int _numberOfLaps;

        private void Awake() => _checkpoints = new List<Checkpoint>();

        private void Start()
        {
            _numberOfLaps = FindObjectOfType<LapsManager>().NumberOfLaps;

            _vehicles = FindObjectOfType<VehiclesManager>().Vehicles;

            _vehiclesCheckpointsProgress = _vehicles.ToDictionary(vehicle => vehicle, checkpoint => 0);
            _vehiclesLapsProgress = _vehicles.ToDictionary(vehicle => vehicle, checkpoint => 0);

            foreach (Transform checkpointTransform in transform)
            {
                Checkpoint checkpoint = checkpointTransform.GetComponent<Checkpoint>();

                _checkpoints.Add(checkpoint);

                checkpoint.SetCheckpointsManager(this);
            }
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

                if (HasFinished(currentLap, currentCheckpoint))
                {
                    FinishEvent?.Invoke(vehicle);
                    Debug.Log("Finish");
                }
                else
                {
                    PositionEvent?.Invoke(vehicle);
                    LapEvent?.Invoke(vehicle);

                    Debug.Log("Full Lap");
                }
            }
            else if (IsCorrectCheckpoint(currentCheckpoint, nextCheckpoint))
            {
                Debug.Log("Correct Checkpoint");

                _vehiclesCheckpointsProgress[vehicle] = nextCheckpoint + 1;

                PositionEvent?.Invoke(vehicle);
            }
            else
            {
                Debug.Log("Wrong Checkpoint");
            }
        }

        private bool IsCorrectCheckpoint(int currentCheckpoint, int nextCheckpoint) => nextCheckpoint == currentCheckpoint;

        private bool IsFullLap(int currentCheckpoint, int nextCheckpoint) => currentCheckpoint == 0
            && nextCheckpoint == _checkpoints.Count;

        private bool HasFinished(int currentLap, int currentCheckpoint) => currentLap >= _numberOfLaps;
    }
}
