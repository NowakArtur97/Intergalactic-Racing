using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace NowakArtur97.IntergalacticRacing.Core
{
    public class Position : MonoBehaviour
    {
        private readonly string DEFAULT_NAME_TEXT = "----------";
        private readonly string NAME_TEXT_UI_NAME = "Name Text (TMP)";
        private readonly string IMAGE_UI_NAME = "Vehicle Image";

        private TextMeshProUGUI _nameText;
        private Image _image;

        private void Awake()
        {
            _nameText = transform.Find(NAME_TEXT_UI_NAME).GetComponentInChildren<TextMeshProUGUI>();
            _image = transform.Find(IMAGE_UI_NAME).GetComponentInChildren<Image>();

            UpdateNameText(DEFAULT_NAME_TEXT);
            UpdateImage(null);
        }

        public void UpdateNameText(string text) => _nameText.text = text;

        public void UpdateImage(Sprite sprite) => _image.sprite = sprite;
    }
}
