using NowakArtur97.IntergalacticRacing.Util;
using UnityEngine;

namespace NowakArtur97.IntergalacticRacing.Core
{
    public class LapsUIManager : MonoBehaviour
    {
        private LapsUI _lapUI;

        private int _currentLap = 1;

        private void Start()
        {
            _lapUI = GetComponentInChildren<LapsUI>();

            _lapUI.UpdateCurrentLapText(_currentLap);
            _lapUI.UpdateTotalLapsText(FindObjectOfType<LapsManager>().NumberOfLaps);

            // TODO: Unsubscibe (?)
            FindObjectOfType<CheckpointsManager>().LapEvent += OnPassLap;
        }

        private void OnPassLap(Vehicle vehicle)
        {
            if (vehicle.CompareTag(GameTags.PLAYER_TAG))
            {
                _lapUI.UpdateCurrentLapText(++_currentLap);
            }
        }
    }
}
