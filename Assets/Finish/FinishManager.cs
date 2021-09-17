using System;
using System.Collections.Generic;
using UnityEngine;

namespace NowakArtur97.IntergalacticRacing.Core
{
    public class FinishManager : MonoBehaviour
    {
        public event Action AllFinishedEvent;

        private int _numberOfVehicles;
        private List<Vehicle> _finishedVehicles;

        private void Awake() => _finishedVehicles = new List<Vehicle>();

        private void Start()
        {
            _numberOfVehicles = FindObjectOfType<VehiclesManager>().Vehicles.Count;

            FindObjectOfType<CheckpointsManager>().FinishEvent += OnVehiclePassFinish;
        }

        private void OnVehiclePassFinish(Vehicle vehicle)
        {
            _finishedVehicles.Add(vehicle);

            if (_finishedVehicles.Count == _numberOfVehicles)
            {
                AllFinishedEvent?.Invoke();
            }
        }
    }
}
