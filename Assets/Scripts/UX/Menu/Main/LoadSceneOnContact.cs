using EasyTransition;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneOnContact : MonoBehaviour
{
    [SerializeField] private SceneAsset sceneToLoad;
    [SerializeField] private TransitionSettings transition;
    [SerializeField] private float startDelay;


    private void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "EggWhites") {
            TriggerGameStart();
        }
    }

    private void TriggerGameStart() {
        TransitionManager.Instance().Transition(sceneToLoad.name, transition, startDelay);
    }
}
