using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public AudioClip MainMusic;
    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = MainMusic;
        audioSource.loop = true;
        audioSource.Play();
    }
}
