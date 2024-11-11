using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Settings : MonoBehaviour
{
    [SerializeField] private SceneAsset settingsScene;

    public void OpenSettings()
    {
        if (!IsSceneLoaded(settingsScene.name))
        {
            SceneManager.LoadScene(settingsScene.name, LoadSceneMode.Additive);
        }
        else
        {
            Debug.Log("Settings scene is already loaded.");
        }
    }

    public void CloseSettings()
    {
        if (IsSceneLoaded(settingsScene.name))
        {
            SceneManager.UnloadSceneAsync(settingsScene.name);
        }
        else
        {
            Debug.Log("Settings scene is not currently loaded.");
        }
    }

    private bool IsSceneLoaded(string sceneName)
    {
        for (int i = 0; i < SceneManager.sceneCount; i++)
        {
            Scene scene = SceneManager.GetSceneAt(i);
            if (scene.name == sceneName)
            {
                return true;
            }
        }
        return false;
    }
}
