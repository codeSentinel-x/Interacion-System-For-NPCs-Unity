using System.Collections;
using System.Collections.Generic;
using NPC_Interaction.ScriptableObjects;
using UnityEngine;

namespace NPC_Interaction.UI {

    public class UI_ItemContentDisplay : MonoBehaviour {
        [SerializeField] private List<ItemSO> _itemsToDisplay = new();
        [SerializeField] private RectTransform _itemDisplayPrefab;

        void Awake() {
            foreach (var item in _itemsToDisplay) {
                var itemDisplay = Instantiate(_itemDisplayPrefab, this.GetComponent<RectTransform>());
                itemDisplay.GetComponentInChildren<UI_ItemDisplay>().Setup(item);
            }
        }
    }
}
