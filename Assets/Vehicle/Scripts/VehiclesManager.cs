using System.Collections.Generic;
using UnityEngine;

namespace NowakArtur97.IntergalacticRacing.Core
{
    // TODO: Random cars and car from Player
    public class VehiclesManager : MonoBehaviour
    {
        [SerializeField] private List<Vehicle> _vehicles;
        public List<Vehicle> Vehicles { get { return _vehicles; } private set { _vehicles = value; } }
    }
}
