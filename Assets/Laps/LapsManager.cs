using UnityEngine;

namespace NowakArtur97.IntergalacticRacing.Core
{
    public class LapsManager : MonoBehaviour
    {
        // TODO: LapsManager: Get number of laps from options/data file (?)
        [SerializeField] private int _numberOfLaps = 2;
        public int NumberOfLaps { get { return _numberOfLaps; } private set { _numberOfLaps = value; } }
    }
}
