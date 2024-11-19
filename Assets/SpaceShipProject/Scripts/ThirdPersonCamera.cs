using System.Threading;
using UnityEngine;

public class ThirdPersonCamera : MonoBehaviour
{
    [SerializeField] private Transform _player;

    float speed = 20f;

    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, _player.position, Time.deltaTime * speed);
        transform.rotation = Quaternion.Lerp(transform.rotation, _player.rotation, Time.deltaTime * speed);
    }
}
