using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class TitleMenu : MonoBehaviour
{
    public Image bg;
    public Light spot;
    public Animator title_anim;
    public Animator cube;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("StartCheck");
    }

    // Update is called once per frame
    void Update()
    {
        spot.color = bg.color;
    }

    IEnumerator StartCheck() {
        while (title_anim.GetCurrentAnimatorStateInfo(0).normalizedTime < 1) {
            yield return null;
        }
        while (true) {
            var _touch = Touchscreen.current;
            var _mouse = Mouse.current;
            if (_touch == null) {
                if (_mouse.leftButton.isPressed) {
                    title_anim.SetBool("isStarted", true);
                    yield return null;
                    while (title_anim.GetCurrentAnimatorStateInfo(0).normalizedTime < 1) {
                        yield return null;
                    }
                    StartCoroutine("ToSelect");
                    yield break;
                }
            }
            else if (_touch.primaryTouch.tap.isPressed) {
                title_anim.SetBool("isStarted", true);
                yield return null;
                while (title_anim.GetCurrentAnimatorStateInfo(0).normalizedTime < 1) {
                    yield return null;
                }
                StartCoroutine("ToSelect");
                yield break;
            }
            yield return null;
        }
    }

    IEnumerator ToSelect() {
        Animator temp_spot = spot.gameObject.GetComponent<Animator>();
        temp_spot.SetBool("isStarted", true);
        yield return null;

        while (temp_spot.GetCurrentAnimatorStateInfo(0).normalizedTime < 1) {
            yield return null;
        }

        cube.SetBool("isStarted", true);
        yield break;
    }
}
