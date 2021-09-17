using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace NowakArtur97.IntergalacticRacing.Core
{
    public class StandingManagerUI : MonoBehaviour
    {
        [SerializeField] private GameObject _standingUI;

        //private void Start() => FindObjectOfType<FinishManager>().AllFinishedEvent += OnAllFinished;

        private void OnEnable()
        {
            Dictionary<Vehicle, PositionStruct> vehiclesPositions = FindObjectOfType<PositionsManager>().VehiclesPositions;

            for (int positionIndex = 0; positionIndex < vehiclesPositions.Count; positionIndex++)
            {
                KeyValuePair<Vehicle, PositionStruct> item = vehiclesPositions.ElementAt(positionIndex);
                Vehicle vehicle = item.Key;
                PositionStruct position = item.Value;

                GameObject standingGO = Instantiate(_standingUI, transform.position, Quaternion.identity);

                standingGO.transform.parent = transform;

                StandingUI standingUI = standingGO.GetComponent<StandingUI>();

                standingUI.UpdatePositionText(positionIndex + 1);
                // TODO: PositionsUIManager: Real name(?)
                standingUI.UpdateNameText(vehicle.gameObject.name);
                standingUI.UpdateTimeText(position.LastCheckpointTime);
                standingUI.UpdateImage(vehicle.GetComponent<SpriteRenderer>().sprite);
            }
        }
    }
}
