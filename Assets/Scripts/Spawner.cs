using System.Collections;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    private Collider spawnerArea;
    public GameObject[] fruitPrefabs;

    public float minSpawnDelay = 0.25f;
    public float maxSpawnDelay = 1f;

    public float minAngle = -15f;
    public float maxAngle = 15f;

    public float minForce = 18f;
    public float maxForce = 22f;

    public float maxLifeTime = 5f;

    private void Awake()
    {
        spawnerArea = GetComponent<Collider>();
    }

    private void OnEnable()
    {
        StartCoroutine(Spawn());
    }
    private void OnDisable()
    {
        StopAllCoroutines();
    }

    private IEnumerator Spawn()
    {
        yield return new WaitForSeconds(2f);
        while (enabled)
        {
            GameObject fruit = fruitPrefabs[Random.Range(0, fruitPrefabs.Length)];

            Vector3 position = new Vector3();
            position.x = Random.Range(spawnerArea.bounds.min.x, spawnerArea.bounds.max.x);
            position.y = Random.Range(spawnerArea.bounds.min.y, spawnerArea.bounds.max.y);
            position.z = Random.Range(spawnerArea.bounds.min.z, spawnerArea.bounds.max.z);

            Quaternion rotation = Quaternion.Euler(0f, 0f, Random.Range(minAngle, maxAngle));

            GameObject prefab = Instantiate(fruit, position, rotation);
            Destroy(prefab, maxLifeTime);

            float force = Random.Range(minForce, maxForce);
            prefab.GetComponent<Rigidbody>().AddForce(prefab.transform.up * force, ForceMode.Impulse);
            yield return new WaitForSeconds(Random.Range(minSpawnDelay, maxSpawnDelay));
        }
    }
}
