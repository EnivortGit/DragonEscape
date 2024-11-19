using UnityEngine;
using System.Collections.Generic;

public class AsteroidsInstances : MonoBehaviour
{
    [System.Serializable]
    private class SpawnableElements
    {
        public int elementNumbers = 20000;
        public float elementRange = 10000;
        public Vector2 elementRndSize = new Vector2(1, 10);
        public List<Transform> elements;
    }
    [SerializeField] private List<SpawnableElements> spawnableElements;

    void Start()
    {
        foreach (SpawnableElements element in spawnableElements) {
            for (int i = 0; i < element.elementNumbers; i++)
            {
                Vector3 pos = Random.insideUnitSphere * element.elementRange;
                Transform newElement = Instantiate(element.elements[Random.Range(0, element.elements.Count)], pos, Random.rotation, transform);
                newElement.localScale = Vector3.one * Random.Range(element.elementRndSize.x, element.elementRndSize.y);
            }
        }
    }
}
