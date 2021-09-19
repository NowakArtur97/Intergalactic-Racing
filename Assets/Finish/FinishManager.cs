using System.Collections.Generic;
using UnityEngine;

namespace NowakArtur97.IntergalacticRacing.Core
{
    public class FinishManager : MonoBehaviour
    {
        [SerializeField] private GameObject _standingManagerUIGO;

        private int _numberOfVehicles;
        private List<Vehicle> _finishedVehicles;

        private void Awake() => _finishedVehicles = new List<Vehicle>();

        private void Start()
        {
            _numberOfVehicles = FindObjectOfType<VehiclesManager>().Vehicles.Count;

            // TODO: Unsubscibe (?)
            FindObjectOfType<CheckpointsManager>().FinishEvent += OnVehiclePassFinish;
        }

        private void OnVehiclePassFinish(Vehicle vehicle)
        {
            _finishedVehicles.Add(vehicle);

            if (_finishedVehicles.Count == _numberOfVehicles)
            {
                // TODO: REFACTOR
                //AllFinishedEvent?.Invoke();
                _standingManagerUIGO.gameObject.SetActive(true);
            }
        }
    }
}
