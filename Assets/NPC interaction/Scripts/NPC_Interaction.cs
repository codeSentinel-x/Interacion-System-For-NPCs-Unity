using System.Collections.Generic;
using NPC_Interaction.CustomFunction;
using NPC_Interaction.NPC_Enums;
using NPC_Interaction.UI;
using TMPro;
using UnityEngine;

namespace NPC_Interaction {
    public class NPC_Interaction : MonoBehaviour, INPC_Chat {

        #region SerializeFields
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
        [SerializeField] private UI_ShopDialogDisplay _ShopDialogDisplay;
        #endregion
        #region Private Variable
        private int _quoteIndex = 0;
        #endregion
        void Awake() {
            _npcInteractionCol.Setup(this);
            _npcNameDisplay.text = _npcName;
            switch (_interactionType) {
                case NPC_Type.ChatNoButtonsNPC: {
                        break;
                    }
                case NPC_Type.ShopNoButtonsNPC: {
                        SetupShopDialogSystem();
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
            _wasIntroduced = false;
        }

        public void Interact() {
            switch (_interactionType) {
                case NPC_Type.ChatNoButtonsNPC: {

                        ChatNpcInteraction();
                        break;
                    }

                case NPC_Type.ShopNoButtonsNPC: {
                        ShopNpcInteraction();
                        break;
                    }
            }
        }
        public void ChatNpcInteraction() {
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
        private bool _wasIntroduced;
        public void ShopNpcInteraction() {
            _ShopDialogDisplay.gameObject.SetActive(true);
            if (_quoteIndex == 0 && _wasIntroduced) {
                HidePanel();
                _shopCanvas.SetActive(true);
            } else {
                ChatNpcInteraction();
                _wasIntroduced = true;
            }

        }
        public void SetupShopDialogSystem() {
            _ShopDialogDisplay._onChatButtonClick.AddListener(ChatNpcInteraction);
            _ShopDialogDisplay._onShopButtonClick.AddListener(() => { _shopCanvas.SetActive(true); HidePanel(); });
            _ShopDialogDisplay._onExitButtonClick.AddListener(HidePanel);
        }
        public string GetNpcName() {
            return _npcName;
        }

        NPC_Type INPC_Chat.GetType() {
            throw new System.NotImplementedException();
        }
    }


}
