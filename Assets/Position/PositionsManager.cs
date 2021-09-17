using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace NowakArtur97.IntergalacticRacing.Core
{
    public class PositionsManager : MonoBehaviour
    {
        public event Action<List<Vehicle>> PositionsEvent;

        public Dictionary<Vehicle, PositionStruct> VehiclesPositions { get; private set; }

        private void Start()
        {
            VehiclesPositions = FindObjectOfType<VehiclesManager>().Vehicles
                .ToDictionary(vehicle => vehicle, checkpoint => new PositionStruct(0, 0));

            // TODO: Unsubscibe (?)
            FindObjectOfType<CheckpointsManager>().PositionEvent += OnUpdatePositions;
        }

        public void OnUpdatePositions(Vehicle vehicle)
        {
            VehiclesPositions[vehicle].CheckpointPassed(Time.time);

            PositionsEvent?.Invoke(VehiclesPositions
                .OrderByDescending(position => position.Value.PassedCheckpoints)
                .ThenBy(position => position.Value.LastCheckpointTime)
                .Select(position => position.Key)
                .ToList());
        }
    }
}
