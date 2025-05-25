using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class BackgroundMusic : MonoBehaviour, IPauseable
{
    public static BackgroundMusic Instance;

    private AudioSource _source;

    public bool IsMuted => _source.mute;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            _source = GetComponent<AudioSource>();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void SetMute(bool mute)
    {
         _source.mute = mute;
    }

    public void Pause()
    {
        _source.Pause();
    }

    public void UnPause()
    {
        _source.UnPause();
    }
}
