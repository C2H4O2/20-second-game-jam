using UnityEngine;
using System.Collections;

public class SaltSpawner : MonoBehaviour
{
    [SerializeField] private GameObject salt;
    [SerializeField] private CircleCollider2D panCollider;
    [SerializeField] private float minSpawnTime = 3f;
    [SerializeField] private float maxSpawnTime = 5f;

    void Start()
    {
        StartCoroutine(SpawnSalt());
    }

    IEnumerator SpawnSalt()
    {
        while (true)
        {
            float spawnTime = Random.Range(minSpawnTime, maxSpawnTime);
            yield return new WaitForSeconds(spawnTime);
            Spawn();
        }
    }

    private void Spawn()
    {
        float spawnRadius = panCollider.radius * panCollider.gameObject.transform.localScale.x; //assume x sf= y sf
        Vector2 randomPosition = new
        Vector2(Random.Range(-spawnRadius,spawnRadius),Random.Range(-spawnRadius,spawnRadius));
        Instantiate(salt, randomPosition, Quaternion.identity);
        Debug.Log("New Salt has spwaned");
    }
}
