using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RewindControl : MonoBehaviour
{
    Transform[] objarray;
    Vector3[] posarray;
    //Quaternion[] rotarray;
    int len;

    // Start is called before the first frame update
    void Start()
    {
        len = transform.childCount - 1;
        objarray = new Transform[len];
        posarray = new Vector3[len];
        //rotarray = new Quaternion[len];
        for (int i = 0; i < len; i++) {
            objarray[i] = transform.GetChild(i);
            posarray[i] = objarray[i].localPosition;
            //rotarray[i] = objarray[i].rotation;
        }
    }

    public void Return() {
        for (int i = 0; i < len; i++) {
            objarray[i].localPosition = posarray[i];
            //objarray[i].rotation = rotarray[i];
        }
    }
}
