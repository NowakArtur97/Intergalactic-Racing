using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace NowakArtur97.IntergalacticRacing.Core
{
    public class StandingsManagerUI : MonoBehaviour
    {
        [SerializeField] private GameObject _standingUI;

        private void OnEnable()
        {
            Dictionary<Vehicle, PositionStruct> vehiclesPositions = FindObjectOfType<PositionsManager>().VehiclesPositions;

            vehiclesPositions = vehiclesPositions
                .OrderByDescending(position => position.Value.PassedCheckpoints)
                .ThenBy(position => position.Value.LastCheckpointTime)
                .ToDictionary(v => v.Key, v => v.Value);

            for (int positionIndex = 0; positionIndex < vehiclesPositions.Count; positionIndex++)
            {
                KeyValuePair<Vehicle, PositionStruct> item = vehiclesPositions.ElementAt(positionIndex);
                Vehicle vehicle = item.Key;
                PositionStruct position = item.Value;

                GameObject standingGO = Instantiate(_standingUI, transform.position, Quaternion.identity);

                standingGO.transform.parent = transform;

                standingGO.GetComponent<StandingUI>().UpdateUI(vehicle, positionIndex + 1, position.LastCheckpointTime);
            }
        }
    }
}
