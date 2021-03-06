using NowakArtur97.IntergalacticRacing.Util;
using TMPro;
using UnityEngine;

namespace NowakArtur97.IntergalacticRacing.Core
{
    public class TimeUI : MonoBehaviour
    {
        private readonly string TOTAL_TIME_TEXT_UI_NAME = "Total Time Text (TMP)";

        private TextMeshProUGUI _totalTimeText;

        private bool _shouldUpdateTime;

        private void Awake()
        {
            _totalTimeText = transform.Find(TOTAL_TIME_TEXT_UI_NAME).GetComponentInChildren<TextMeshProUGUI>();
            _shouldUpdateTime = true;
        }

        // TODO: Unsubscibe (?)
        private void Start()
        {
            PlayerVehicle player = FindObjectOfType<PlayerVehicle>();

            if (player != null)
            {
                player.PlayerFinished += OnPlayerFinished;
            }
        }

        private void Update()
        {
            if (_shouldUpdateTime)
            {
                _totalTimeText.text = TimeUtil.ToTime(Time.time);
            }
        }

        private void OnPlayerFinished() => _shouldUpdateTime = false;
    }
}
