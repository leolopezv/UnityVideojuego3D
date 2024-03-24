using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] itemPrefab;
    public float minTime = 1f;
    public float maxTime = 2f;
    public float despawnTime = 5f; 
    public Vector2 spawnAreaSize = new Vector2(5f, 5f); 

    void Start()
    {
        StartCoroutine(SpawnCoroutine(0));
    }

    IEnumerator SpawnCoroutine(float waitTime)
    {
    while (true)
        {
            yield return new WaitForSeconds(waitTime);
            Vector3 spawnPosition = GetRandomSpawnPosition();

            if (Physics.OverlapSphere(spawnPosition, 0.5f).Length == 0)
            {
                GameObject spawnedItem = Instantiate(itemPrefab[Random.Range(0, itemPrefab.Length)], spawnPosition, Quaternion.Euler(Random.Range(0f, 360f), Random.Range(0f, 360f), Random.Range(0f, 360f)));
                StartCoroutine(DespawnItem(spawnedItem, despawnTime));
            }

            waitTime = Random.Range(minTime, maxTime);
        }
    }

    Vector3 GetRandomSpawnPosition()
    {
        float randomX = transform.position.x + Random.Range(-spawnAreaSize.x / 2f, spawnAreaSize.x / 2f);
        float randomZ = transform.position.z + Random.Range(-spawnAreaSize.y / 2f, spawnAreaSize.y / 2f);
        
        randomX = Mathf.Clamp(randomX, transform.position.x - spawnAreaSize.x / 2f, transform.position.x + spawnAreaSize.x / 2f);
        randomZ = Mathf.Clamp(randomZ, transform.position.z - spawnAreaSize.y / 2f, transform.position.z + spawnAreaSize.y / 2f);

        return new Vector3(randomX, transform.position.y, randomZ);
    }

    IEnumerator DespawnItem(GameObject item, float time)
    {
        yield return new WaitForSeconds(time);
        Destroy(item);
    }

}
