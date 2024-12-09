using UnityEngine;

public class DifficultyManager : MonoBehaviour
{
    private bool Difficulty;
    [SerializeField] bool forceDifficulty;
    [SerializeField] private GameObject[] hardGameObjects;
    [SerializeField] private GameObject[] easyGameObjects;

    [SerializeField] private float hardSpeed;

    [SerializeField] private float easySpeed;

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
            SetFollowSpeed(easySpeed, easyGameObjects); // Set FollowSpeed to 15 for easyGameObjects
        }
        else
        {
            EnableObjects(hardGameObjects);
            DisableObjects(easyGameObjects);
            SetFollowSpeed(hardSpeed, hardGameObjects); // Set FollowSpeed to 10 for hardGameObjects
        }
    }

    private void EnableObjects(GameObject[] gameObjects)
    {
        foreach (var gameObject in gameObjects)
        {
            gameObject.SetActive(true);
        }
    }

    private void DisableObjects(GameObject[] gameObjects)
    {
        foreach (var gameObject in gameObjects)
        {
            gameObject.SetActive(false);
        }
    }

    private void SetFollowSpeed(float speed, GameObject[] gameObjects)
    {
        foreach (GameObject gameObject in gameObjects)
        {
            Spatula spatula = gameObject.GetComponent<Spatula>();
            if (spatula != null)
            {
                spatula.FollowSpeed = speed;
            }
        }
    }
}
