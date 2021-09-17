using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace NowakArtur97.IntergalacticRacing.Core
{
    public class PositionsManager : MonoBehaviour
    {
        private Dictionary<Vehicle, PositionStruct> _vehiclesPositions;

        private PositionsUIManager _positionsUIManager;

        private void Start()
        {
            _vehiclesPositions = FindObjectOfType<VehiclesManager>().Vehicles
                .ToDictionary(vehicle => vehicle, checkpoint => new PositionStruct(0, 0));

            _positionsUIManager = FindObjectOfType<PositionsUIManager>();
        }

        public void UpdatePositions(Vehicle vehicle)
        {
            _vehiclesPositions[vehicle].CheckpointPassed(Time.time);

            List<Vehicle> orderedVehiclesPositions = _vehiclesPositions
                .OrderByDescending(position => position.Value.PassedCheckpoints)
                .ThenBy(position => position.Value.LastCheckpointTime)
                .Select(position => position.Key)
                .ToList();

            _positionsUIManager.UpdatePositionsUI(orderedVehiclesPositions);
        }
    }
}
