using UnityEngine;

public class RandomiseControls : MonoBehaviour
{
    private Timer timer;
    private ButtonList buttonList;
    private int randomiseCount = 0;
    [SerializeField] private int change1 = 15;
    [SerializeField] private int change2 = 7;

    private void Awake() {
        timer = FindAnyObjectByType<Timer>();
        buttonList = FindFirstObjectByType<ButtonList>();
    }

    private void Update() {
        if(timer.Time < change1 && randomiseCount == 0) {
            randomiseCount++;
            buttonList.ReRandomise();
        }
        if(timer.Time < change2 && randomiseCount == 1) {
            randomiseCount++;
            buttonList.ReRandomise();
        }
    }
}
