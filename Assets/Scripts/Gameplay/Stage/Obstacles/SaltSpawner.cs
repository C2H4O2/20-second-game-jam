using UnityEngine;
using System.Collections;

public class SaltSpawner : MonoBehaviour
{
    [SerializeField] Timer timer;
    [SerializeField] private GameObject salt;
    [SerializeField] private CircleCollider2D panCollider;
    [SerializeField] private float spawnTime = 3.5f;

    private void Awake() {
        timer = FindAnyObjectByType<Timer>();
    }
    void Start()
    {
        StartCoroutine(SpawnSalt());
    }

    IEnumerator SpawnSalt()
    {
        while (timer.TimerOn)
        {
            yield return new WaitForSeconds(spawnTime);
            Spawn();
        }
    }

    private void Spawn()
    {   //fix salt spawning ontop of player
        float spawnRadius = panCollider.radius * panCollider.gameObject.transform.localScale.x; //assume x sf= y sf
        Vector2 randomPosition = new
        Vector2(Random.Range(-spawnRadius,spawnRadius),Random.Range(-spawnRadius,spawnRadius));
        Instantiate(salt, randomPosition, Quaternion.identity);
        Debug.Log("New Salt has spwaned");
    }
}
