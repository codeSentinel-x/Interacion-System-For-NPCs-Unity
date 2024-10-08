using NPC_Interaction.ScriptableObjects;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace NPC_Interaction.UI {

    [RequireComponent(typeof(Image))]
    public class UI_ItemsDisplay : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler {
        [SerializeField] private Transform _panelTop;
        [SerializeField] private Transform _panelBottom;
        private Image _imageDisplay;
        private ItemSO _itemSO;
        private Item _item;
        public void Setup(ItemSO itemSO) {
            _imageDisplay = _imageDisplay != null ? _imageDisplay : GetComponent<Image>();
            _itemSO = itemSO;
            _item = new() { _base = _itemSO };
            _imageDisplay.sprite = _itemSO._itemSprite;
            _panelTop.Find("Name").GetComponent<TextMeshProUGUI>().text = _itemSO._name;
            _panelBottom.Find("Price").GetComponent<TextMeshProUGUI>().text = $"{_itemSO._price}$";
            var t = _panelBottom.Find("Rarity").GetComponent<TextMeshProUGUI>();
            t.text = _itemSO._rarity.ToString();
            t.color = _itemSO._rarity switch {
                ItemRarity.common => Color.white,
                ItemRarity.uncommon => Color.cyan,
                ItemRarity.rare => Color.green,
                ItemRarity.epic => Color.blue,
                ItemRarity.legendary => Color.yellow,
                ItemRarity.mythical => Color.red,
                _ => Color.white,
            };

        }
        public ItemSO GetItemSO() {
            return _itemSO;
        }

        public void OnPointerEnter(PointerEventData eventData) {
            UI_ItemsTooltip.Show(_item);
        }

        public void OnPointerExit(PointerEventData eventData) {
            UI_ItemsTooltip.Hide();
        }
    }
}

