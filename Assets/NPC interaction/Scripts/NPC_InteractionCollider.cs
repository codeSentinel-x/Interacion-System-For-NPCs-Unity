using System.Collections;
using System.Collections.Generic;
using NPC_Interaction.Player;
using TMPro;
using UnityEngine;

namespace NPC_Interaction {

    public class NPC_InteractionCollider : MonoBehaviour {
        private NPC_Interaction _npcInteraction;

        public void Setup(NPC_Interaction npc) {
            _npcInteraction = npc;
        }
        void OnTriggerEnter2D(Collider2D other) {
            if (other.TryGetComponent<Player_Interaction>(out var inter)) {
                Debug.Log("Player entered interaction collider");
                inter._currentInteraction = _npcInteraction;
            } else {
                Debug.Log("Something else than player entered interaction collider. Ignoring");
            }
        }
        void OnTriggerExit2D(Collider2D other) {
            if (other.TryGetComponent<Player_Interaction>(out var inter)) {
                Debug.Log("Player exited interaction collider");
                if (inter._currentInteraction == _npcInteraction) {
                    inter._currentInteraction = null;
                    _npcInteraction.HidePanel();
                }
            } else {
                Debug.Log("Something else than player exited interaction collider. Ignoring");
            }
        }


    }
}
