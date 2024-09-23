using System.Collections.Generic;
using NPC_Interaction.CustomFunction;
using NPC_Interaction.NPC_Enums;
using NPC_Interaction.UI;
using TMPro;
using UnityEngine;

namespace NPC_Interaction {
    public class NPC_Dialog : MonoBehaviour, INPC_Chat {
        #region SerializeFields
        [Header("Variables")]
        [SerializeField] private string _npcName;
        [SerializeField] private List<string> _quotes = new();
        [SerializeField] private float _textInterval;
        [Header("Enums")]
        [SerializeField] private NPC_QuoteType _quoteType;

        [Header("Components")]
        [SerializeField] private NPC_InteractionCollider _npcInteractionCol;
        [SerializeField] private Collider2D _interactionCollider;
        [SerializeField] private SpriteRenderer _spriteRenderer;
        [SerializeField] private TextMeshPro _npcNameDisplay;
        [SerializeField] private TextDisplay _npcTextDisplay;
        #endregion
        #region Private Variable
        private int _quoteIndex = 0;
        #endregion

        void Awake() {
            _npcInteractionCol.Setup(this);
            _npcNameDisplay.text = _npcName;
        }

        public void HidePanel() {
            _npcTextDisplay.Hide();
            _quoteIndex = 0;
        }

        public void Interact() {
            if (!_npcTextDisplay.gameObject.activeInHierarchy) _npcTextDisplay.Show();
            if (_npcTextDisplay.TrySkipTextDisplay()) return;
            switch (_quoteType) {
                case NPC_QuoteType.Random: {
                        _npcTextDisplay.DisplayText(CustomFunctions.GetRandomElement<string>(_quotes), _textInterval);
                        break;
                    }
                case NPC_QuoteType.InOrder: {
                        _npcTextDisplay.DisplayText(_quotes[_quoteIndex], _textInterval);
                        _quoteIndex++;
                        if (_quoteIndex >= _quotes.Count) HidePanel();
                        break;

                    }
            }
        }

        public string GetNpcName() {
            return _npcName;
        }

        NPC_Type INPC_Chat.GetType() => NPC_Type.ChatNoButtonsNPC;
    }

}
