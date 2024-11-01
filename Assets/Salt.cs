using UnityEngine;
using System.Collections;

public class Salt : MonoBehaviour
{
    private UnityEngine.GameObject salt;
    [SerializeField] public float minSpawnTime = 3f;
    [SerializeField] public float maxSpawnTime = 5f;

    private void Awake()
    {
        salt = GameObject.FindWithTag("Salty");
    }

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

    void Spawn()
    {
        Vector2 randomPosition = new
        Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f));
        Instantiate(salt, randomPosition, Quaternion.identity);
        Debug.Log("New Salt has spwaned");
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            Debug.Log("The " + other.gameObject.name + " collected the salt");
            Destroy(salt);
        }
    }

}
