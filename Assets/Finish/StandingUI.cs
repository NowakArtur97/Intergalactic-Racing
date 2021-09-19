using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace NowakArtur97.IntergalacticRacing.Core
{
    public class StandingUI : MonoBehaviour
    {
        // PositionUI: Get Player name from menu
        [SerializeField] private string _playerName = "Player Vehicle";

        [Header("Colors")]
        [SerializeField] private Color _playerTextColor = Color.blue;
        [SerializeField] private Color _aITextColor = Color.red;

        private readonly string POSITION_TEXT_UI_NAME = "Position Text (TMP)";
        private readonly string NAME_TEXT_UI_NAME = "Name Text (TMP)";
        private readonly string TIME_TEXT_UI_NAME = "Time Text (TMP)";
        private readonly string IMAGE_UI_NAME = "Vehicle Image";

        private TextMeshProUGUI _positionText;
        private TextMeshProUGUI _nameText;
        private TextMeshProUGUI _timeText;
        private Image _image;

        private void Awake()
        {
            _positionText = transform.Find(POSITION_TEXT_UI_NAME).GetComponentInChildren<TextMeshProUGUI>();
            _nameText = transform.Find(NAME_TEXT_UI_NAME).GetComponentInChildren<TextMeshProUGUI>();
            _timeText = transform.Find(TIME_TEXT_UI_NAME).GetComponentInChildren<TextMeshProUGUI>();
            _image = transform.Find(IMAGE_UI_NAME).GetComponentInChildren<Image>();
        }

        public void UpdateUI(Vehicle vehicle, int position, double time)
        {
            // TODO: PositionUI: Get Player name from vehicle
            string playerName = vehicle.gameObject.name;

            bool isPlayer = _playerName.Equals(playerName);

            UpdatePositionText(position, isPlayer);
            UpdateNameText(playerName, isPlayer);
            UpdateTimeText(time, isPlayer);
            UpdateImage(vehicle.GetComponent<SpriteRenderer>().sprite);
        }

        private void UpdatePositionText(int text, bool isPlayer)
        {
            _positionText.color = isPlayer ? _playerTextColor : _aITextColor;
            _positionText.text = text + ".";
        }

        private void UpdateNameText(string name, bool isPlayer)
        {
            _nameText.color = isPlayer ? _playerTextColor : _aITextColor;
            _nameText.text = name;
        }

        private void UpdateTimeText(double time, bool isPlayer)
        {
            _timeText.color = isPlayer ? _playerTextColor : _aITextColor;
            _timeText.text = time + "";
        }

        private void UpdateImage(Sprite sprite) => _image.sprite = sprite;
    }
}
