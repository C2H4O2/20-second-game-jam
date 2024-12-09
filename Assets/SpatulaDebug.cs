using TMPro;
using UnityEngine;

public class SpatulaDebug : MonoBehaviour
{
    public TMP_Text followSpeedText;
    public TMP_Text smoothingText;
    public Spatula spatula;
    void Update()
    {
        followSpeedText.text = spatula.FollowSpeed.ToString();
        smoothingText.text = spatula.FollowSmoothness.ToString();
    }
}
