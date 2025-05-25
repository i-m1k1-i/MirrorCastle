using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Toggle))]
public class BackgroundMusicToggle : MonoBehaviour
{
    private Toggle _musicToggle;

    private void Awake()
    {
        _musicToggle = GetComponent<Toggle>();
    }

    private void OnEnable()
    {
        if (_musicToggle != null)
        {
            _musicToggle.isOn = !BackgroundMusic.Instance.IsMuted;
            _musicToggle.onValueChanged.AddListener(OnToggleMusic);
        }
    }

    private void OnToggleMusic(bool isOn)
    {
        BackgroundMusic.Instance.SetMute(!isOn);
    }
}
