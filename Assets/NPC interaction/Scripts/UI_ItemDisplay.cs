using NPC_Interaction.ScriptableObjects;
using UnityEngine;
using UnityEngine.UI;

namespace NPC_Interaction.UI {

    [RequireComponent(typeof(Image))]
    public class UI_ItemDisplay : MonoBehaviour {
        private Image _imageDisplay;
        private ItemSO _itemSO;
        public void Setup(ItemSO itemSO) {
            _imageDisplay ??= GetComponent<Image>();
            _itemSO = itemSO;
            _imageDisplay.sprite = _itemSO._itemSprite;
        }
        public ItemSO GetItemSO() {
            return _itemSO;
        }
    }
}
