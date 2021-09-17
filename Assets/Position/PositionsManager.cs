using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace NowakArtur97.IntergalacticRacing.Core
{
    public class PositionsManager : MonoBehaviour
    {
        public event Action<List<Vehicle>> PositionsEvent;

        private Dictionary<Vehicle, PositionStruct> _vehiclesPositions;

        private void Start()
        {
            _vehiclesPositions = FindObjectOfType<VehiclesManager>().Vehicles
                .ToDictionary(vehicle => vehicle, checkpoint => new PositionStruct(0, 0));

            FindObjectOfType<CheckpointsManager>().PositionEvent += UpdatePositions;
        }

        public void UpdatePositions(Vehicle vehicle)
        {
            _vehiclesPositions[vehicle].CheckpointPassed(Time.time);

            PositionsEvent?.Invoke(_vehiclesPositions
                .OrderByDescending(position => position.Value.PassedCheckpoints)
                .ThenBy(position => position.Value.LastCheckpointTime)
                .Select(position => position.Key)
                .ToList());
        }

        private void OnDestroy() => FindObjectOfType<CheckpointsManager>().PositionEvent -= UpdatePositions;
    }
}
