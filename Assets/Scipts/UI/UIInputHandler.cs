using UnityEngine;

public class UIInputHandler : MonoBehaviour
{
    [SerializeField] private GameObject _pauseMenu;
    [SerializeField] private InputReader _input;

    private void OnEnable()
    {
        _pauseMenu.SetActive(false);

        _input.PauseEvent += TogglePauseMenu;
        _input.RestartLevelEvent += RestartLevel;
        _input.LevelSelectorEvent += OpenLevelSelectorScene;
    }

    private void OnDisable()
    {
        _input.PauseEvent -= TogglePauseMenu;
        _input.RestartLevelEvent -= RestartLevel;
        _input.LevelSelectorEvent -= OpenLevelSelectorScene;
    }

    private void TogglePauseMenu()
    {
        _pauseMenu.SetActive(!_pauseMenu.activeSelf);
        GameManager.Instance.SetPause(_pauseMenu.activeSelf);
    }

    private void RestartLevel()
    {
        GameManager.Instance.RestartLevel();
        DisablePauseMenu();
    }

    private void OpenLevelSelectorScene()
    {
        GameManager.Instance.OpenLevelSelectorScene();
        DisablePauseMenu();
    }

    private void DisablePauseMenu()
    {
        _pauseMenu.SetActive(false);
        GameManager.Instance.SetPause(false);
    }
}
