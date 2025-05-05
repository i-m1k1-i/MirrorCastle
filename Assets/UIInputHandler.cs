using UnityEngine;

public class UIInputHandler : MonoBehaviour
{
    [SerializeField] private GameObject _pauseMenu;
    [SerializeField] private InputReader _input;

    private void OnEnable()
    {
        _pauseMenu.SetActive(false);

        _input.PauseEvent += TogglePauseMenu;
        _input.RestartLevelEvent += GameManager.Instance.RestartLevel;
        _input.LevelSelectorEvent += GameManager.Instance.LoadLevelSelector;
    }

    private void OnDisable()
    {
        _input.PauseEvent -= TogglePauseMenu;
        _input.RestartLevelEvent -= GameManager.Instance.RestartLevel;
        _input.LevelSelectorEvent -= GameManager.Instance.LoadLevelSelector;
    }

    private void TogglePauseMenu()
    {
        _pauseMenu.SetActive(!_pauseMenu.activeSelf);
        GameManager.Instance.SetPause(_pauseMenu.activeSelf);
    }
}
