using UnityEngine;

public class Laser : MonoBehaviour
{
    [SerializeField] private string colliderName;
    [SerializeField] private float speed = 500f, destroyTime = 5;

    private void Update()
    {
        transform.Translate(transform.forward * Time.deltaTime * speed, Space.World);
        destroyTime -= Time.deltaTime;
        if (destroyTime < 0) Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.name.Contains(colliderName))
        {
            other.GetComponent<MeshRenderer>().enabled = false;
            other.transform.GetChild(0).GetComponent<ParticleSystem>().Play();
            other.transform.GetComponent<SphereCollider>().enabled = false;
            Destroy(other.gameObject, 2);
            Destroy(gameObject);
        }
    }
}
