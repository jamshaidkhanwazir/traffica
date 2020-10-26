using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioClip ButtonSound;
    public AudioClip Track;

    private AudioSource BackgroundTrackAudioSource;
    private AudioSource SFXAudioSource;

    public static AudioManager _instance;
    public static AudioManager Instance
    {
        get { return _instance; }
    }

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(gameObject);
            return;
        }
        _instance = this;
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        BackgroundTrackAudioSource = transform.GetComponent<AudioSource>();
        BackgroundTrackAudioSource.clip = Track;
        BackgroundTrackAudioSource.Play();
        SFXAudioSource = FindObjectOfType<GameManager>().GetComponent<AudioSource>();
        SFXAudioSource.clip = ButtonSound;

        SetMusicVolume(PreferenceManager.Music);
        SetSFXVolume(PreferenceManager.SFX);
    }

    public void SetMusicVolume(float _value)
    {
        BackgroundTrackAudioSource.volume = _value;
    }

    public void SetSFXVolume(float _value)
    {
        SFXAudioSource.volume = _value;
    }

    public void PlayButtonSound()
    {
        SFXAudioSource.Play();
    }
}
