using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace NowakArtur97.IntergalacticRacing.Core
{
    public class PositionsManager : MonoBehaviour
    {
        [SerializeField] private List<Vehicle> _vehicles;

        private Dictionary<Vehicle, int> _vehiclesPositions;

        private void Awake() => _vehiclesPositions = _vehicles.ToDictionary(vehicle => vehicle, checkpoint => 0);

        public void UpdatePositions(Vehicle vehicle)
        {
            _vehiclesPositions[vehicle]++;
        }
    }
}
