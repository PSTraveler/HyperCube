using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxMove : MonoBehaviour
{
    public GameObject eventcenter;
    GameObject player;
    Vector3 direction;
    float curr = 0;
    public bool isClicked = false;

    void FixedUpdate()
    {
        if (isClicked) {
            if (Mathf.Abs(direction.x) > Mathf.Abs(direction.z)) {
                float dist = Time.fixedDeltaTime * Mathf.Clamp(direction.x, -1.0f, 1.0f);
                transform.Translate(new Vector3(dist, 0, 0), Space.World);
                curr += Mathf.Abs(dist);
            }
            else {
                float dist = Time.fixedDeltaTime * Mathf.Clamp(direction.z, -1.0f, 1.0f);
                transform.Translate(new Vector3(0, 0, dist), Space.World);
                curr += Mathf.Abs(dist);
            }
            if (curr >= 1.25f) {
                player = null;
                direction = Vector3.zero;
                isClicked = false;
                curr = 0;
            }
        }

    }

    private void OnCollisionEnter(Collision other) {
        if (other.gameObject.CompareTag("Player") && !isClicked) {
            player = other.gameObject;
            direction = transform.position - other.transform.position;
        }
    }

    private void OnCollisionStay(Collision other) {
        if (other.gameObject.CompareTag("Player") && !isClicked) {
            direction = transform.position - other.transform.position;
            if (eventcenter.GetComponent<SwitchControl>().isBoxMove) {
                isClicked = true;
                eventcenter.GetComponent<SwitchControl>().isBoxMove = false;
            }
        }
    }

    private void OnCollisionExit(Collision other) {
        if (other.gameObject.CompareTag("Player") && !isClicked) {
            player = null;
            direction = Vector3.zero;
        }
    }
}
