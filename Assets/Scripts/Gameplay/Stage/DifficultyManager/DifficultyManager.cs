using UnityEngine;

public class DifficultyManager : MonoBehaviour
{
    private bool Difficulty;
    [SerializeField] bool forceDifficulty;
    [SerializeField] private GameObject[] spatulaGameobjects;

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
            for (int i = 1; i < spatulaGameobjects.Length; i++)
            {
                spatulaGameobjects[i].SetActive(false); 
            }
        }
    }
}
