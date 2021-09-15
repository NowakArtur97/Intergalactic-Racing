using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace NowakArtur97.IntergalacticRacing.Core
{
    public class PositionsManager : MonoBehaviour
    {
        [SerializeField] private List<Vehicle> _vehicles;

        public Dictionary<Vehicle, int> VehiclesPositions { get; private set; }

        private PositionsUIManager _positionsUIManager;

        private void Awake() => VehiclesPositions = _vehicles.ToDictionary(vehicle => vehicle, checkpoint => 0);

        private void Start() => _positionsUIManager = FindObjectOfType<PositionsUIManager>();

        public void UpdatePositions(Vehicle vehicle)
        {
            VehiclesPositions[vehicle]++;

            List<Vehicle> tempVehiclesPositions = VehiclesPositions
                .OrderByDescending(position => position.Value)
                .Select(position => position.Key)
                .ToList();

            _positionsUIManager.UpdatePositionsUI(tempVehiclesPositions);
        }
    }
}
