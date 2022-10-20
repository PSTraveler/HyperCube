using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalTo180 : MonoBehaviour
{
    public GameObject stage;
    GameObject player;
    public float speed = 30;
    Transform portal;
    float rot180 = 0;
    float currot = 0;
    bool isEnter = false;
    
    void Start()
    {
        portal = transform.GetChild(0);
        Debug.Log(portal);
    }

    void FixedUpdate()
    {
        if (isEnter) {
            rot180 += Time.fixedDeltaTime * speed;
            if (rot180 >= 180.0f)
                rot180 = 180.0f;
            stage.transform.rotation = Quaternion.Euler(stage.transform.eulerAngles.x, stage.transform.eulerAngles.y, currot + rot180);
            //stage.transform.Rotate(new Vector3(0, 0, Time.fixedDeltaTime * speed));
        }
        else {
            currot = stage.transform.eulerAngles.z;
        }
        if (rot180 >= 180.0f) {
            rot180 = 0;
            isEnter = false;
            player.GetComponent<PlayerMove>().enabled = true;
            player.GetComponent<Rigidbody>().useGravity = true;
            if (portal == transform.GetChild(0)) portal = transform;
            else portal = transform.GetChild(0);
        }
    }

    private void OnTriggerEnter(Collider other) {
        if (other.tag == "Player" && !isEnter) {
            player = other.gameObject;
            isEnter = true;
            player.GetComponent<PlayerMove>().enabled = false;
            player.transform.position = portal.position + new Vector3(0, -1.0f, 0);
            player.transform.Rotate(new Vector3(0, 0, 180));
            player.GetComponent<Rigidbody>().useGravity = false;
        }
    }
}
