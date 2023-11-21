using TMPro;
using UnityEngine;

namespace UI
{
    public sealed class TextWidget : MonoBehaviour
    {
        [SerializeField]
        private TextMeshProUGUI text;

        public string Text
        {
            get => text.text;
            set => text.text = value;
        }
    }
}