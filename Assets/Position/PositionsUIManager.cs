using System.Collections.Generic;
using UnityEngine;
using System.Linq;

namespace NowakArtur97.IntergalacticRacing.Core
{
    public class PositionsUIManager : MonoBehaviour
    {
        private List<Position> _positions;
        private Dictionary<Vehicle, int> _vehiclesPositions;

        private void Awake() => _positions = new List<Position>();

        private void Start()
        {
            _vehiclesPositions = FindObjectOfType<PositionsManager>().VehiclesPositions;

            foreach (Transform positionTransform in transform)
            {
                Position position = positionTransform.GetComponent<Position>();

                _positions.Add(position);
            }
        }

        public void UpdatePositionUI(Vehicle vehicle)
        {
            List<Vehicle> tempVehiclesPositions = _vehiclesPositions
                .OrderByDescending(position => position.Value)
                .ToDictionary(position => position.Key, position => position.Value)
                .Keys
                .ToList();

            for (int positionIndex = 0; positionIndex < tempVehiclesPositions.Count; positionIndex++)
            {
                Position position = _positions[positionIndex];

                // TODO: PositionsUIManager: Real name(?)
                position.UpdateNameText(tempVehiclesPositions[positionIndex].gameObject.name);
                position.UpdateImage(tempVehiclesPositions[positionIndex].GetComponent<SpriteRenderer>().sprite);
            }
        }
    }
}
