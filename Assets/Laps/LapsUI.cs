using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace NowakArtur97.IntergalacticRacing.Core
{
    public class LapsUI : MonoBehaviour
    {
        private readonly string LAPS_DIVIDER = "/";
        private readonly string CURRENT_LAP_TEXT_UI_NAME = "Current Lap Text (TMP)";
        private readonly string TOTAL_LAPS_TEXT_UI_NAME = "Total Laps Text (TMP)";

        private TextMeshProUGUI _currentLapText;
        private TextMeshProUGUI _totalLapsText;
        private Image _image;

        private void Awake()
        {
            _currentLapText = transform.Find(CURRENT_LAP_TEXT_UI_NAME).GetComponentInChildren<TextMeshProUGUI>();
            _totalLapsText = transform.Find(TOTAL_LAPS_TEXT_UI_NAME).GetComponentInChildren<TextMeshProUGUI>();
        }

        public void UpdateCurrentLapText(int position) => _currentLapText.text = position + "";

        public void UpdateTotalLapsText(int position) => _totalLapsText.text = LAPS_DIVIDER + position;
    }
}
