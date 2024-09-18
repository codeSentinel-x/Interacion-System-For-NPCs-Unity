using UnityEngine;

namespace NPC_Interaction.ScriptableObjects {

    [CreateAssetMenu(menuName = "NPC_InteractionSystem/ScriptableObjects/ItemSO")]
    public class ItemSO : ScriptableObject {
        public Sprite _itemSprite;
        public ItemRarity _rarity;
        public string _name;
        public string _shortDescription;

        [TextArea] public string _longDescription;
        [Min(0.1f)] public float _price;
    }
    public enum ItemRarity {
        common,
        uncommon,
        rare,
        epic,
        legendary,
        mythical,
    }
}

