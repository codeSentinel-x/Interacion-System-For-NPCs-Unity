using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace NPC_Interaction.Player {

    public class Player_Interaction : MonoBehaviour {
        public static Player_Interaction _Instance;
        public NPC_Interaction _currentInteraction;
        [SerializeField] private KeyCode _interactionKey;

        void Awake() {
            _Instance = this;
        }
        void Update() {
            if (_currentInteraction == null) return;
            if (Input.GetKeyDown(_interactionKey)) {
                _currentInteraction.Interact();
                Debug.Log($"Player interacted with {_currentInteraction.GetNpcName()}");
            }
        }
    }
}
