using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraWork_Tutorial : MonoBehaviour
{
    public GameObject camera_P;
    int child_C = 1;
    Transform cur_child;
    bool isClicked = false;

    void Start() {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (isClicked) {
            transform.position = Vector3.Lerp(transform.position, cur_child.position, Time.fixedDeltaTime * 2);
            transform.rotation = Quaternion.Lerp(transform.rotation, cur_child.rotation, Time.fixedDeltaTime * 3);
            if (Vector3.Distance(transform.position, cur_child.position) < 0.001f && transform.rotation == cur_child.rotation) isClicked = false;
        }
    }

    public void Change_Position() {
        if (child_C == 0)
            GetComponent<Camera>().orthographic = true;
        else GetComponent<Camera>().orthographic = false;

        cur_child = camera_P.transform.GetChild(child_C);
        isClicked = true;
        child_C++;
        if (child_C == camera_P.transform.childCount) {
            child_C = 0;
        }
    }
}
