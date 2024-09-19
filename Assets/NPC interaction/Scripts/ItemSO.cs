using UnityEngine;

namespace NPC_Interaction.ScriptableObjects {

    [CreateAssetMenu(menuName = "NPC_InteractionSystem/ScriptableObjects/ItemSO")]
    public class ItemSO : ScriptableObject {
        public Sprite _itemSprite;
        public ItemRarity _rarity;
        public string _name;
        public string _shortDescription;
        public ItemType _type;
        [TextArea] public string _longDescription;
        [Min(0.1f)] public float _price;

        [Header("Armor stats")]
        public int _armorBonus;
        public int _damageBonus;
        public int _speedBonus;
        public float _armorMultiplier;
        public float _speedMultiplier;
        public float _damageMultiplier;
        public int _additionalBagCapacity;


    }
    public enum ItemRarity {
        common,
        uncommon,
        rare,
        epic,
        legendary,
        mythical,
    }
    public enum ItemType {
        Usable,
        Armor,
        Weapon,
    }
}

