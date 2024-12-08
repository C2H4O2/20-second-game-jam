using EasyTransition;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneOnContact : MonoBehaviour
{
    [SerializeField] private string sceneToLoad;
    [SerializeField] private TransitionSettings transition;
    [SerializeField] private float startDelay;

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("EggWhites")) { 
            TriggerGameStart();
        }
    }

    public void TriggerGameStart() {
        if (!string.IsNullOrEmpty(sceneToLoad)) {
            TransitionManager.Instance().Transition(sceneToLoad, transition, startDelay);
        } else {
            Debug.LogWarning("Scene name is empty! Please assign a valid scene name in the Inspector.");
        }
    }
}
