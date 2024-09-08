using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NPC_Interaction {

    public class NPC_InteractionCollider : MonoBehaviour {
        private NPC_Interaction _NPC_Interaction;


        public void Setup(NPC_Interaction npc) {
            _NPC_Interaction = npc;
        }
    }
}
