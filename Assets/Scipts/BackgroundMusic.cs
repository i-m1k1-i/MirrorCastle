using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class BackgroundMusic : MonoBehaviour
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

    public void UnPause()
    {
        _source.UnPause();
    }

    public void Pause()
    {
        _source.Pause();
    }
}
