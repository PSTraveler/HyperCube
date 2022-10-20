using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameClear : MonoBehaviour
{
    public Camera cam;
    public Canvas clearUI;
    public Canvas controlUI;

    private void OnTriggerEnter(Collider other) {
        if (other.tag == "Player") {
            if (!cam.orthographic)
                cam.gameObject.GetComponent<CameraWork_Tutorial>().Change_Position();
            
            controlUI.enabled = false;
            clearUI.enabled = true;
        }
    }
}
