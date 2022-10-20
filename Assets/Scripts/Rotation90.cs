using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation90 : MonoBehaviour
{
    public GameObject stage;
    GameObject player;
    Quaternion rot;
    public int dir = 1;
    public float speed = 10;
    float rot90 = 0;
    float sumrot = 0;
    float currot_x = 0;
    float currot_z = 0;
    float tlspeed = 0;
    bool isEnter = false;

    void Start()
    {
        currot_x = stage.transform.eulerAngles.x;
        currot_z = stage.transform.eulerAngles.z;
        rot90 = Time.fixedDeltaTime * speed;
        tlspeed = Time.fixedDeltaTime * speed * (1.25f/ 90.0f);
    }

    void FixedUpdate()
    {
        if (isEnter) {
            if (player.transform.parent == stage.transform) {
                player.transform.parent = transform;
                player.GetComponent<Rigidbody>().useGravity = false;
            }

            sumrot += rot90;
            if (sumrot >= 90.0f)
                sumrot = 90.0f;

            rot = transform.rotation;

            if (dir == 1) {
                player.transform.Translate(new Vector3(tlspeed, 0, 0));
                stage.transform.rotation = Quaternion.Euler(stage.transform.eulerAngles.x, stage.transform.eulerAngles.y, currot_z + sumrot);
            }
            else if (dir == -1) {
                player.transform.Translate(new Vector3(-tlspeed, 0, 0));
                stage.transform.rotation = Quaternion.Euler(stage.transform.eulerAngles.x, stage.transform.eulerAngles.y, currot_z - sumrot);
            }
            else if (dir == 2) {
                player.transform.Translate(new Vector3(0, 0, tlspeed));
                stage.transform.rotation = Quaternion.Euler(currot_x + sumrot, stage.transform.eulerAngles.y, stage.transform.eulerAngles.z);
            }
            else if (dir == -2) {
                player.transform.Translate(new Vector3(0, 0, -tlspeed));
                stage.transform.rotation = Quaternion.Euler(currot_x - sumrot, stage.transform.eulerAngles.y, stage.transform.eulerAngles.z);
            }
            transform.rotation = rot;
        }
        else {
            currot_x = stage.transform.eulerAngles.x;
            currot_z = stage.transform.eulerAngles.z;
        }

        if (sumrot >= 90.0f) {
            player.transform.parent = stage.transform;
            player.GetComponent<PlayerMove>().enabled = true;
            player.GetComponent<Rigidbody>().useGravity = true;
            isEnter = false;
            sumrot = 0;
            dir = -dir;
        }
    }

    private void OnTriggerEnter(Collider other) {
        if (other.tag == "Player") {
            player = other.gameObject;
            isEnter = true;
            player.GetComponent<PlayerMove>().enabled = false;
        }
    }
}
