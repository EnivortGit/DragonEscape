using System.Collections;
using System.Collections.Generic;
using Unity.Hierarchy;
using Unity.VisualScripting;
using UnityEngine;

public class DragonController : MonoBehaviour {
    [SerializeField] private float rotationSpeed = 100.0F;
    [SerializeField] private float currentSpeed = 100f;
    [SerializeField] private Animator anim;

    // starting value for the Lerp
    static float lerpTime = 0.0f;

    void Update()
    {
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
        float rotationSpeedHorizontal = Input.GetAxis("Horizontal") * rotationSpeed * Time.deltaTime;

        transform.Rotate(0, rotationSpeedHorizontal, 0);
    }
}
