using System.Collections.Generic;
using NPC_Interaction.NPC_Enums;
using NPC_Interaction.UI;
using TMPro;
using UnityEngine;

namespace NPC_Interaction {

    public class NPC_DialogWithWindow : MonoBehaviour, INPC_Chat {
        #region SerializeFields
        [Header("Variables")]
        [SerializeField] private string _npcName;
        [SerializeField] private List<string> _quotes = new();
        [SerializeField] private float _textInterval;
        [SerializeField] private GameObject _windowCanvas;
        [Header("Components")]
        [SerializeField] private NPC_InteractionCollider _npcInteractionCol;
        [SerializeField] private Collider2D _interactionCollider;
        [SerializeField] private SpriteRenderer _spriteRenderer;
        [SerializeField] private TextMeshPro _npcNameDisplay;
        [SerializeField] private TextDisplay _npcTextDisplay;
        #endregion
        #region Private Variable
        private int _quoteIndex = 0;
        private bool _wasIntroduced = false;
        #endregion
        void Awake() {
            _npcInteractionCol.Setup(this);
            _npcNameDisplay.text = _npcName;
        }


        public void HidePanel() {
            _npcTextDisplay.Hide();
            _quoteIndex = 0;
            _wasIntroduced = false;
        }

        public void Interact() {
            if (_quoteIndex == 0 && _wasIntroduced) {
                HidePanel();
                _windowCanvas.SetActive(true);
            } else {
                ChatNpcInteraction();
                _wasIntroduced = true;
            }

        }

        public void ChatNpcInteraction() {
            if (!_npcTextDisplay.gameObject.activeInHierarchy) _npcTextDisplay.Show();
            if (_npcTextDisplay.TrySkipTextDisplay()) return;
            _npcTextDisplay.DisplayText(_quotes[_quoteIndex], _textInterval);
            _quoteIndex++;
            if (_quoteIndex >= _quotes.Count) _quoteIndex = 0;
        }

        public string GetNpcName() {
            return _npcName;
        }
    }
}
