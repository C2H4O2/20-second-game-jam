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
    private AudioSource audioSource;
    private List<Song> remainingSongs;
    private static MusicManager instance;

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
        if (!audioSource.isPlaying && audioSource.clip != null)
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
}
