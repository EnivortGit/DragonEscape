using System.Collections;
using System.Collections.Generic;
using Unity.Hierarchy;
using Unity.VisualScripting;
using UnityEngine;

public class ShipController : MonoBehaviour {

    public float speed = 100.0F;
    public float speedMax = 200.0F;

    public float rotationSpeed = 100.0F;

    private float currentSpeed = 0f, acceleration = 1f, boostAcceleration = 2f;
    [SerializeField] private ParticleSystem thrusterLeft, thrusterCenter, thrusterRight;

    // starting value for the Lerp
    static float lerpTime = 0.0f;

    void Update()
    {
        if (Input.GetButton("Jump"))
        {
            SetTrusterParticule(thrusterCenter, true);
            // Set speed
            if (Input.GetButton("Fire3")) {
                if (lerpTime < 1)
                {
                    lerpTime += acceleration * Time.deltaTime;
                    currentSpeed = Mathf.Lerp(0, speed, lerpTime);
                }
                else 
                {
                    if (lerpTime < 2) lerpTime += boostAcceleration * Time.deltaTime;
                    currentSpeed = Mathf.Lerp(speed, speedMax, lerpTime - 1);
                }
            }
            else
            {
                if (lerpTime > 1)
                {
                    currentSpeed = Mathf.Lerp(speed, speedMax, lerpTime - 1);
                    lerpTime -= boostAcceleration * Time.deltaTime;
                }
                else
                {
                    currentSpeed = Mathf.Lerp(0, speed, lerpTime);
                    lerpTime += boostAcceleration * Time.deltaTime;
                }
            } 

        }
        else
        {
            SetTrusterParticule(thrusterCenter, false);
            if (lerpTime > 1)
            {
                currentSpeed = Mathf.Lerp(speed, speedMax, lerpTime - 1);
                lerpTime -= boostAcceleration * Time.deltaTime;
            }
            else if (lerpTime > 0)
            {
                currentSpeed = Mathf.Lerp(0, speed, lerpTime);
                lerpTime -= acceleration * Time.deltaTime;
            }
        }

        float rotationSpeedVertical = Input.GetAxis("Vertical") * rotationSpeed * Time.deltaTime;
        float rotationSpeedHorizontal = Input.GetAxis("Horizontal") * rotationSpeed * Time.deltaTime;
        
        if (Input.GetAxis("Horizontal") > 0)
        {
            SetTrusterParticule(thrusterLeft, true);
        }
        else if (Input.GetAxis("Horizontal") < 0)
        {
            SetTrusterParticule(thrusterRight, true);
        }
        else
        {
            SetTrusterParticule(thrusterLeft, false);
            SetTrusterParticule(thrusterRight, false);
        }

        transform.Translate(0, 0, currentSpeed * Time.deltaTime);
        transform.Rotate(rotationSpeedVertical, rotationSpeedHorizontal, 0);
    }

    private void SetTrusterParticule(ParticleSystem thruster, bool launch)
    {
        if (launch && !thruster.isPlaying)
        {
            thruster.Play();
        }

        if (!launch && thruster.isPlaying)
        {
            thruster.Stop();
        }
    }
}
