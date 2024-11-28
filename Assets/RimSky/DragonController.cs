using System.Collections;
using System.Collections.Generic;
using Unity.Hierarchy;
using Unity.VisualScripting;
using UnityEngine;

public class DragonController : MonoBehaviour {
    [SerializeField] private float rotationSpeed = 100.0F;
    [SerializeField] private float currentSpeed = 100f;
    [SerializeField] private Animator anim;
    [SerializeField] private Vector2 limitX, limitY;

    // starting value for the Lerp
    static float lerpTime = 0.0f;

    void Update()
    {
        if (Input.GetButton("Jump")) {
            anim.SetBool("Attack", true);
            //TODO: Spawn fire
        }
        else
        {
            anim.SetBool("Attack", false);
            if (Input.GetAxis("Vertical") > 0)
            {
                print("translate");
                transform.Translate(0, 0, currentSpeed * Time.deltaTime);
                anim.SetBool("FlyForward", true);
            }
            else
            {
                anim.SetBool("FlyForward", false);
            }
            float rotationSpeedHorizontal = 0;

            if (transform.position.x < limitX.y && Input.GetAxis("Horizontal") > 0)
            {
                rotationSpeedHorizontal = rotationSpeed * Time.deltaTime;
            }
            if (transform.position.x < limitX.x)
            {

            }
            rotationSpeedHorizontal = Input.GetAxis("Horizontal") * rotationSpeed * Time.deltaTime;
            transform.Translate(rotationSpeedHorizontal, 0, 0);
        }
    }
}
