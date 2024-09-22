using UnityEngine;

namespace NPC_Interaction {

    public interface INPC_Chat {
        public void Interact();
        public void HidePanel();
        public string GetNpcName();
    }
}
