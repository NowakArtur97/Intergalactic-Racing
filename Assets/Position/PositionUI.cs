using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace NowakArtur97.IntergalacticRacing.Core
{
    public class PositionUI : MonoBehaviour
    {
        private readonly string POSITION_TEXT_UI_NAME = "Position Text (TMP)";
        private readonly string NAME_TEXT_UI_NAME = "Name Text (TMP)";
        private readonly string IMAGE_UI_NAME = "Vehicle Image";

        private TextMeshProUGUI _positionText;
        private TextMeshProUGUI _nameText;
        private Image _image;

        private void Awake()
        {
            _positionText = transform.Find(POSITION_TEXT_UI_NAME).GetComponentInChildren<TextMeshProUGUI>();
            _nameText = transform.Find(NAME_TEXT_UI_NAME).GetComponentInChildren<TextMeshProUGUI>();
            _image = transform.Find(IMAGE_UI_NAME).GetComponentInChildren<Image>();
        }

        public void UpdatePositionText(int text) => _positionText.text = text + ".";

        public void UpdateNameText(string text) => _nameText.text = text;

        public void UpdateImage(Sprite sprite) => _image.sprite = sprite;
    }
}
