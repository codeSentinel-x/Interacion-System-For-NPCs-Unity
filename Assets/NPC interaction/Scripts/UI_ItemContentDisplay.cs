using System.Collections.Generic;
using System.Linq;
using NPC_Interaction.ScriptableObjects;
using UnityEngine;

namespace NPC_Interaction.UI {

    public class UI_ItemContentDisplay : MonoBehaviour {
        [SerializeField] private List<ItemSO> _itemsToDisplay = new();
        [SerializeField] private RectTransform _itemDisplayPrefab;
        public ItemData[] _items;
        void Awake() {
            _items = new ItemData[_itemsToDisplay.Count];
            int i = 0;
            foreach (var item in _itemsToDisplay) {
                var itemDisplay = Instantiate(_itemDisplayPrefab, this.GetComponent<RectTransform>());
                itemDisplay.GetComponentInChildren<UI_ItemsDisplay>().Setup(item);
                _items[i] = new ItemData() { parent = itemDisplay, _cost = item._price, _rarity = (int)item._rarity, _ID = i };
                i++;
            }
        }
        public void SortItems(int sortType = 0) { //0 - default, 1 - price ASC, 2 - price DESC, 3 - Rarity ASC, 4 - Rarity DESC
            List<ItemData> sortedList = new();
            switch (sortType) {
                case 0: {
                        sortedList = _items.ToList();
                        break;
                    }
                case 1: {
                        sortedList = _items.OrderBy((ItemData i) => i._cost).ToList();
                        break;
                    }
                case 2: {
                        sortedList = _items.OrderByDescending((ItemData i) => i._cost).ToList();
                        break;
                    }
                case 3: {
                        sortedList = _items.OrderBy((ItemData i) => i._rarity).ToList();
                        break;
                    }
                case 4: {
                        sortedList = _items.OrderByDescending((ItemData i) => i._rarity).ToList();
                        break;
                    }
            }
            var g = new GameObject("parent");
            foreach (var it in sortedList) {
                it.parent.SetParent(g.transform);
            }
            foreach (var it in sortedList) {
                it.parent.SetParent(this.GetComponent<RectTransform>());
            }
            Destroy(g);
        }
    }
    public class ItemData {
        public Transform parent;
        public float _cost;
        public int _rarity;
        public int _ID;
    }

}
