using System.Collections.Generic;
using UnityEngine;

namespace NowakArtur97.IntergalacticRacing.Core
{
    public class PositionsUIGenerator : MonoBehaviour
    {
        [SerializeField] private GameObject _positonUI;

        private void Start() => GeneratePositionsUI(FindObjectOfType<VehiclesManager>().Vehicles);

        private void GeneratePositionsUI(List<Vehicle> vehicles)
        {
            List<PositionUI> positionsUI = new List<PositionUI>();

            for (int index = 0; index < vehicles.Count; index++)
            {
                Vehicle vehicle = vehicles[index];

                GameObject positionGO = Instantiate(_positonUI, transform.position, Quaternion.identity);

                positionGO.transform.parent = transform;

                PositionUI positionUI = positionGO.GetComponent<PositionUI>();

                // TODO: PositionsUIManager: Real name(?)
                positionUI.UpdatePositionText(index + 1);
                positionUI.UpdateNameText(vehicle.gameObject.name);
                positionUI.UpdateImage(vehicle.GetComponent<SpriteRenderer>().sprite);

                positionsUI.Add(positionUI);
            }

            FindObjectOfType<PositionsUIManager>().SetPositionsUI(positionsUI);
        }
    }
}
