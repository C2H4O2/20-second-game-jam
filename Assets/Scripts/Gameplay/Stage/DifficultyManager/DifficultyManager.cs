using UnityEngine;

public class DifficultyManager : MonoBehaviour
{
    private bool Difficulty;
    [SerializeField] bool forceDifficulty;
    [SerializeField] private GameObject[] hardGameObjects;
    [SerializeField] private GameObject[] easyGameObjects;

    private void Awake()
    {
        Difficulty = GetDifficulty("difficulty");
        if (forceDifficulty)
        {
            Difficulty = true;
        }
    }

    public bool GetDifficulty(string key, bool defaultValue = false)
    {
        return PlayerPrefs.GetInt(key, defaultValue ? 1 : 0) == 1;
    }

    private void Start()
    {
        ManageSpatulas();
    }

    private void ManageSpatulas()
    {
        if (!Difficulty)
        {
            EnableObjects(easyGameObjects);
            DisableObjects(hardGameObjects);
        }
        else if(Difficulty) {
            EnableObjects(hardGameObjects);
            DisableObjects(easyGameObjects);
        }
    }

    private void EnableObjects(GameObject[] gameObjects) {
        foreach (var gameObject in gameObjects)
        {
            gameObject.SetActive(true);
        }
    }

    private void DisableObjects(GameObject[] gameObjects) {
        foreach (var gameObject in gameObjects)
        {
            gameObject.SetActive(false);
        }
    }
}
