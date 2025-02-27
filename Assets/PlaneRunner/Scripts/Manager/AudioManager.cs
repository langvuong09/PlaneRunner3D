using UnityEngine;
[AddComponentMenu("TienCuong/AudioManager")]
public class AudioManager : MonoBehaviour
{
    [Header("Audio Source")]
    public AudioSource MusicSource;
    [Header("Audio Clip")]
    public AudioClip backgroundMusic;
    private static AudioManager instance;
    public static AudioManager Instance
    {
        get => instance;
    }
    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(gameObject);
    }
    void Start()
    {
        PlayBackGroundMusic();
    }
    void PlayBackGroundMusic()
    {
        MusicSource.clip = backgroundMusic;
        MusicSource.Play();
        MusicSource.loop = true;
    }
}
