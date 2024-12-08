using UnityEngine;

public class RestartMusic : MonoBehaviour
{
    private void Start() {
        MusicManager.instance.ResumeTrack();
    }
}
