using System.Collections;
using System.Runtime.InteropServices.WindowsRuntime;
using TMPro;
using Unity.Collections;
using Unity.VisualScripting;
using UnityEngine;

namespace NPC_Interaction {

    public class TextDisplay : MonoBehaviour {
        private TextMeshProUGUI _textDisplay;
        private string _currentText;
        private bool _isCoroutineRunning;
        void Awake() {
            _textDisplay = GetComponent<TextMeshProUGUI>();
            Hide();
        }
        public void Show() {
            transform.parent.gameObject.SetActive(true);
        }
        public void Hide() {
            StopCoroutine();
            _textDisplay.text = "";
            transform.parent.gameObject.SetActive(false);
        }
        public void StopCoroutine() {
            _isCoroutineRunning = false;
            StopAllCoroutines();
        }

        public bool TrySkipTextDisplay() {
            if (_isCoroutineRunning) {
                StopCoroutine();
                _textDisplay.text = _currentText;
                return true;
            } else {
                return false;
            }

        }
        public void DisplayText(string text, float interval = 0.1f) {
            _currentText = text;
            Debug.Log($"{_currentText} and {_currentText.Length}");
            if (interval == 0) {
                _textDisplay.text = text;
            } else {
                StopCoroutine();
                StartCoroutine(DisplayTextInInterval(interval));
            }
        }
        private IEnumerator DisplayTextInInterval(float interval) {
            _textDisplay.text = "";
            bool isRichText = false;
            _isCoroutineRunning = true;
            for (int i = 0; i < _currentText.Length; i++) {
                var c = _currentText[i];
                if (i > 0) {
                    if (_currentText[i - 1] != '\\') {
                        if (c == '<') isRichText = true;
                        else if (c == '>') isRichText = false;
                    }
                    if (c == '\\' && _currentText[i - 1] != '\\') continue;
                } else if (c == '\\') continue;

                _textDisplay.text += c;

                if (!isRichText) {
                    if (c == ' ') continue;
                    yield return new WaitForSeconds(interval);
                }
            }
            _isCoroutineRunning = false;


        }
    }
}
