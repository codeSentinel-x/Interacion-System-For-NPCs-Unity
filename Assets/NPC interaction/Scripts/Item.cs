using NPC_Interaction.ScriptableObjects;

namespace NPC_Interaction {

    public class Item {
        public ItemSO _base;
        public string GetEquipableItemStatsInString() {
            string statsString = "";
            if (_base._armorBonus != 0) statsString += $"Armor: {CreateStatBonusString(_base._armorBonus)}\n";
            if (_base._damageBonus != 0) statsString += $"Damage: {CreateStatBonusString(_base._damageBonus)}\n";
            if (_base._speedBonus != 0) statsString += $"Speed: {CreateStatBonusString(_base._speedBonus)}\n";
            if (_base._additionalBagCapacity != 0) statsString += $"Bag capacity: {CreateStatBonusString(_base._additionalBagCapacity)}\n";
            if (_base._armorMultiplier != 0) statsString += $"Armor multiplier: {_base._armorMultiplier:f1}\n";
            if (_base._speedMultiplier != 0) statsString += $"Speed multiplier: {_base._speedMultiplier:f1}\n";
            if (_base._damageMultiplier != 0) statsString += $"Damage multiplier: {_base._damageMultiplier:f1}\n";
            return statsString;
        }
        private string CreateStatBonusString(int value) => $"{((value > 0) ? "+" : "-")}{value}";

    }
}
