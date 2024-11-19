using UnityEngine;
using System.Collections.Generic;
public class LaserShoot : MonoBehaviour
{
    [SerializeField] private List<Transform> shooters;
    [SerializeField] private Transform laser;
    [SerializeField] private float laserFireDelay = 0.5f;

    private float laserCurrentFireDelay;

    private void Update()
    {
        if (Input.GetButton("Fire1") && laserCurrentFireDelay <= 0)
        {
            laserCurrentFireDelay = laserFireDelay;
            foreach (Transform shooter in shooters)
            {
                Transform newLaser = Instantiate(laser, shooter.position, shooter.rotation);
            }
        }
        else
        {
            laserCurrentFireDelay -= Time.deltaTime;
        }
    }

}
