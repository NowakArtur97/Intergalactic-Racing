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
                GameObject positionGO = Instantiate(_positonUI, transform.position, Quaternion.identity);

                positionGO.transform.parent = transform;

                PositionUI positionUI = positionGO.GetComponent<PositionUI>();

                positionUI.UpdateUI(vehicles[index], index + 1);

                positionsUI.Add(positionUI);
            }

            FindObjectOfType<PositionsUIManager>().SetPositionsUI(positionsUI);
        }
    }
}
