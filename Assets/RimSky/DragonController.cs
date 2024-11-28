using System.Collections;
using System.Collections.Generic;
using Unity.Hierarchy;
using Unity.VisualScripting;
using UnityEngine;

public class DragonController : MonoBehaviour {
    [SerializeField] private float rotationSpeed = 100.0F;
    [SerializeField] private float currentSpeed = 100f;

    // starting value for the Lerp
    static float lerpTime = 0.0f;

    void Update()
    {
        if (Input.GetButton("Jump"))
        {

            transform.Translate(0, 0, currentSpeed * Time.deltaTime);
        }
        float rotationSpeedHorizontal = Input.GetAxis("Horizontal") * rotationSpeed * Time.deltaTime;


        transform.Rotate(Vector3.zero, rotationSpeedHorizontal, 0);
    }
}
