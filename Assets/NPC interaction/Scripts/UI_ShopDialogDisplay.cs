using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace NPC_Interaction.UI {

    public class UI_ShopDialogDisplay : MonoBehaviour {
        [SerializeField] private Button _chatButton;
        [SerializeField] private Button _shopButton;
        [SerializeField] private Button _exitButton;
        public UnityEvent _onChatButtonClick;
        public UnityEvent _onExitButtonClick;
        public UnityEvent _onShopButtonClick;

        void Awake() {
            _chatButton.onClick.AddListener(_onChatButtonClick.Invoke);
            _shopButton.onClick.AddListener(_onShopButtonClick.Invoke);
            _exitButton.onClick.AddListener(_onExitButtonClick.Invoke);
        }

    }
}
