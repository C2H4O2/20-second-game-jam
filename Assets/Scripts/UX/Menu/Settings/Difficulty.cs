using UnityEngine;
using UnityEngine.UI;

public class Difficulty : MonoBehaviour
{
    public void SetHard() {
        SetDifficulty("difficulty", true);
    }

    public void SetEasy() {
        SetDifficulty("difficulty", false);
    }
    public void SetDifficulty(string key, bool value)
    {
        PlayerPrefs.SetInt(key, value ? 1 : 0);
    }

    public bool GetDifficulty(string key, bool defaultValue = false)
    {
        return PlayerPrefs.GetInt(key, defaultValue ? 1 : 0) == 1;
    }
}
