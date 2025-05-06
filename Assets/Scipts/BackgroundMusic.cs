using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class BackgroundMusic : MonoBehaviour, IPauseable
{
    public static BackgroundMusic Instance;

    private AudioSource _source;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            _source = GetComponent<AudioSource>();
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
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
