using NPC_Interaction.NPC_Enums;
using UnityEngine;

namespace NPC_Interaction {
    public class NPC_Interaction : MonoBehaviour {
        [SerializeField] private NPC_InteractionCollider _npcInteractionCol;
        [SerializeField] private Collider2D _interactionCollider;
        [SerializeField] private SpriteRenderer _spriteRenderer;
        [SerializeField] private NPC_Type _type;

        void Awake() {
            _npcInteractionCol.Setup(this);
            switch (_type) {
                case NPC_Type.ChatNPC: {

                        break;
                    }
                case NPC_Type.ShopNPC: {

                        break;
                    }
                default: {
                        Debug.LogError("Error ocurred");
                        break;
                    }

            }

        }
    }

}
