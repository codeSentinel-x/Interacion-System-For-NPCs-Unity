using System.Collections.Generic;
using UnityEngine;

namespace NPC_Interaction.CustomFunction {

    public static class CustomFunctions {
        public static T GetRandomElement<T>(T[] array) {
            return array[Random.Range(0, array.Length)];
        }
        public static T GetRandomElement<T>(List<T> list) {
            return list[Random.Range(0, list.Count)];
        }

    }
}
