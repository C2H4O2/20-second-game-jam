using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Song
{
    public string songName;
    public AudioClip clip;
}

public class MusicManager : MonoBehaviour
{
    [SerializeField] private List<Song> musicPlaylist;
    [SerializeField] private float fadeDuration = 1f; // Duration of fade-in/out
    
    private AudioSource audioSource;
    private List<Song> remainingSongs;
    private static MusicManager instance;
    private Coroutine fadeCoroutine;
    private bool paused;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            return;
        }
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }
        remainingSongs = new List<Song>(musicPlaylist);
    }

    private void Start()
    {
        PlayNextSong();
    }

    private void Update()
    {
        if (!audioSource.isPlaying && audioSource.clip != null && !paused)
        {
            PlayNextSong();
        }
    }

    private void PlayNextSong()
    {
        if (remainingSongs.Count == 0)
        {
            remainingSongs = new List<Song>(musicPlaylist);
        }

        Song nextSong = ChooseRandomSong();
        remainingSongs.Remove(nextSong);
        Debug.Log($"Now Playing: {nextSong.songName}");
        audioSource.clip = nextSong.clip;
        audioSource.Play();
    }

    private Song ChooseRandomSong()
    {
        int generatedSongIndex = Random.Range(0, remainingSongs.Count);
        return remainingSongs[generatedSongIndex];
    }

    public void PauseTrack()
    {
        paused = true;
        if (fadeCoroutine != null)
        {
            StopCoroutine(fadeCoroutine);
        }
        fadeCoroutine = StartCoroutine(FadeVolume(0f, fadeDuration, () => audioSource.Pause()));
    }

    public void ResumeTrack()
    {
        paused = false;
        if (fadeCoroutine != null)
        {
            StopCoroutine(fadeCoroutine);
        }
        audioSource.UnPause();
        fadeCoroutine = StartCoroutine(FadeVolume(1f, fadeDuration));
    }

    private IEnumerator FadeVolume(float targetVolume, float duration, System.Action onComplete = null)
    {
        float startVolume = audioSource.volume;
        float elapsedTime = 0f;

        while (elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;
            audioSource.volume = Mathf.Lerp(startVolume, targetVolume, elapsedTime / duration);
            yield return null;
        }

        audioSource.volume = targetVolume;
        onComplete?.Invoke();
    }
}
