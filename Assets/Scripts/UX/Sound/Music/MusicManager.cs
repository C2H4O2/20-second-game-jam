using UnityEngine;

public class MusicManager : MonoBehaviour
{
    [SerializeField] private AudioClip MainMusic;
    private AudioSource audioSource;

    void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);
    }

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = MainMusic;
        audioSource.loop = true;
        audioSource.Play();
    }
}
