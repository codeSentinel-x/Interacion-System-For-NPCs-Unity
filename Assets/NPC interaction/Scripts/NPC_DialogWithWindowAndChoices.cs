using System.Collections.Generic;
using NPC_Interaction.NPC_Enums;
using NPC_Interaction.UI;
using TMPro;
using UnityEngine;

namespace NPC_Interaction {

    public class NPC_DialogWithWindowAndChoices : MonoBehaviour, INPC_Chat {
        #region SerializeFields
        [Header("Variables")]
        [SerializeField] private string _npcName;
        [SerializeField] private List<string> _quotes = new();
        [SerializeField] private float _textInterval;
        [SerializeField] private GameObject _shopCanvas;
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
        private bool _wasIntroduced = false;
        #endregion
        void Awake() {
            _npcInteractionCol.Setup(this);
            _npcNameDisplay.text = _npcName;
            SetupShopDialogSystem();
        }

        public void SetupShopDialogSystem() {
            _ShopDialogDisplay._onChatButtonClick.AddListener(ChatNpcInteraction);
            _ShopDialogDisplay._onShopButtonClick.AddListener(() => { _shopCanvas.SetActive(true); HidePanel(); });
            _ShopDialogDisplay._onExitButtonClick.AddListener(HidePanel);
        }

        public void HidePanel() {
            _npcTextDisplay.Hide();
            _quoteIndex = 0;
            _wasIntroduced = false;
        }

        public void Interact() {
            _ShopDialogDisplay.gameObject.SetActive(true);
            if (_quoteIndex == 0 && _wasIntroduced) {
                HidePanel();
                _shopCanvas.SetActive(true);
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

        NPC_Type INPC_Chat.GetType() => NPC_Type.ShopWithButtonsNPC;
    }
}
