using System.Collections.Generic;
using NPC_Interaction.CustomFunction;
using NPC_Interaction.NPC_Enums;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

namespace NPC_Interaction {
    public class NPC_Interaction : MonoBehaviour {

        #region Public Variable
        [Header("Variables")]
        [SerializeField] private string _npcName;
        [SerializeField] private List<string> _quotes = new();
        [SerializeField] private float _textInterval;
        [SerializeField] private GameObject _shopCanvas;
        [Header("Enums")]
        [SerializeField] private NPC_Type _interactionType;
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
            switch (_interactionType) {
                case NPC_Type.SimpleChatNPC: {
                        break;
                    }
                case NPC_Type.ShopNPC: {

                        break;
                    }
                default: {
                        Debug.Log("<color=red>Error ocurred. There's no behaviour for given npc type</color>");
                        break;
                    }

            }

        }
        public void HidePanel() {
            _npcTextDisplay.Hide();
            _quoteIndex = 0;
        }
        
        public void Interact() {
            switch (_interactionType) {
                case NPC_Type.SimpleChatNPC: {
                        if (!_npcTextDisplay.gameObject.activeInHierarchy) _npcTextDisplay.Show();
                        if (_npcTextDisplay.TrySkipTextDisplay()) return;
                        ChatNpcInteraction();
                        break;
                    }
                    
                case NPC_Type.ShopNPC: {
                        ShopNpcInteraction();
                        _shopCanvas.SetActive(true);
                        break;
                    }
            }
        }
        public void ChatNpcInteraction() {
            switch (_quoteType) {
                case NPC_QuoteType.Random: {
                        _npcTextDisplay.DisplayText(CustomFunctions.GetRandomElement<string>(_quotes), _textInterval);
                        break;
                    }
                case NPC_QuoteType.InOrder: {
                        _npcTextDisplay.DisplayText(_quotes[_quoteIndex], _textInterval);
                        _quoteIndex++;
                        if (_quoteIndex >= _quotes.Count) _quoteIndex = 0;
                        break;

                    }
            }
        }
        public void ShopNpcInteraction() {

        }
        public string GetNpcName() {
            return _npcName;
        }
    }

}
