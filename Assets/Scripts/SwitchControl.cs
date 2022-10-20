using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchControl : MonoBehaviour
{
    public GameObject player;
    public bool isBoxMove = false;

    void Update() {
        if (isBoxMove && !player.GetComponent<PlayerMove>().isCollision) {
            isBoxMove = false;
        }
    }

    public void Interact() {
        isBoxMove = true;
    }
}
