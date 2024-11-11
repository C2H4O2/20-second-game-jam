using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
    [SerializeField] private SceneAsset pauseScene;

    public void OpenPause()
    {
        if (!IsSceneLoaded(pauseScene.name))
        {
            SceneManager.LoadScene(pauseScene.name, LoadSceneMode.Additive);
        }
        else
        {
            Debug.Log("Pause scene is already loaded.");
        }
    }

    public void ClosePause()
    {
        if (IsSceneLoaded(pauseScene.name))
        {
            SceneManager.UnloadSceneAsync(pauseScene.name);
        }
        else
        {
            Debug.Log("Pause scene is not currently loaded.");
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
