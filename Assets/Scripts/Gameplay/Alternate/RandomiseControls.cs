using UnityEngine;

public class RandomiseControls : MonoBehaviour
{
    private Timer timer;
    private ButtonList buttonList;
    private int randomiseCount = 0;

    private void Awake() {
        timer = FindAnyObjectByType<Timer>();
        buttonList = FindFirstObjectByType<ButtonList>();
    }

    private void Update() {
        if(timer.Time < 15 && randomiseCount == 0) {
            randomiseCount++;
            buttonList.ReRandomise();
        }
        if(timer.Time < 7 && randomiseCount == 1) {
            randomiseCount++;
            buttonList.ReRandomise();
        }
    }
}
