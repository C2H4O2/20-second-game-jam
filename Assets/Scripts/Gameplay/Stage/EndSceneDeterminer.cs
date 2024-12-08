using UnityEngine;

public class EndSceneDeterminer : MonoBehaviour
{
    [SerializeField] private LoadSceneOnContact winScene;
    [SerializeField] private LoadSceneOnContact loseSceneSalty;
    [SerializeField] private SaltMeter saltMeter;

    public void LoadSceneBasedOnSalt() {
        if(saltMeter.isSaltMeterEnough()) {
            winScene.TriggerGameStart();
        }
        else {
            loseSceneSalty.TriggerGameStart();
        }
    }
}
