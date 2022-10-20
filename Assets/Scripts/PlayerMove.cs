using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.OnScreen;

public class PlayerMove : MonoBehaviour
{
    public GameObject stick_image;
    public float speed = 1;
    public float widthLimit = 5.0f;
    public float heightLimit = 5.0f;
    Vector2 origin;
    public bool isCollision = false;
    public bool isLimit = true;

    void Start()
    {
        origin = new Vector2(stick_image.transform.localPosition.x, stick_image.transform.localPosition.y);
    }

    void FixedUpdate()
    {
        if (isLimit)
            transform.position = new Vector3(Mathf.Clamp(transform.position.x, -widthLimit, widthLimit), transform.position.y, Mathf.Clamp(transform.position.z, -heightLimit, heightLimit));
        if (origin.x != stick_image.transform.localPosition.x && origin.y != stick_image.transform.localPosition.y)
            transform.Translate(new Vector3(origin.y - stick_image.transform.localPosition.y, 0, stick_image.transform.localPosition.x - origin.x).normalized * Time.fixedDeltaTime * speed);
    }

    private void OnCollisionEnter(Collision other) {
        if (other.gameObject.CompareTag("Object")) {
            isCollision = true;
        }
    }

    private void OnCollisionExit(Collision other) {
        if (other.gameObject.CompareTag("Object")) {
            isCollision = false;
        }
    }
}
