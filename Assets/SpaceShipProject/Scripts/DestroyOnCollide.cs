using UnityEngine;

public class DestroyOnCollide : MonoBehaviour
{
    [SerializeField] private string colliderName;
    [SerializeField] private ParticleSystem particuleObject;

    private void OnTriggerEnter(Collider other)
    {
        if (other.name.Contains(colliderName))
        {
            gameObject.GetComponent<MeshRenderer>().enabled = false;
            particuleObject.Play();
        }
    }
}
