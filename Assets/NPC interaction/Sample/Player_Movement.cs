using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NPC_Interaction.Player {

    public class Player_Movement : MonoBehaviour {
        [SerializeField] private float _speed;

        void Update() {
            transform.position += _speed * Time.deltaTime * new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized;
        }
    }
}

