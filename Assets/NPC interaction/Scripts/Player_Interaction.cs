using UnityEngine;

namespace NPC_Interaction.Player {

    public class Player_Interaction : MonoBehaviour {
        public static Player_Interaction _Instance;
        public INPC_Chat _currentInteraction;
        [SerializeField] private KeyCode _interactionKey;

        void Awake() {
            _Instance = this;
        }
        void Update() {
            if (_currentInteraction != null) {
                if (Input.GetKeyDown(_interactionKey)) {
                    Debug.Log(_currentInteraction.GetType());
                    _currentInteraction.Interact();
                    Debug.Log($"Player interacted with {_currentInteraction.GetNpcName()}");
                }
            }
        }
    }
}
