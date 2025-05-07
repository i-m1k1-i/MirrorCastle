using UnityEngine;
using UnityEngine.SceneManagement;

public class UIInputHandler : MonoBehaviour
{
    [SerializeField] private GameObject _pauseMenuGO;
    [SerializeField] private InputReader _input;

    private bool _canPauseInScene = false;

    private void OnEnable()
    {
        _input.PauseEvent += TogglePauseMenu;
        _input.RestartLevelEvent += OnRestartLevel;
        _input.LevelSelectorEvent += OnOpenLevelSelectorScene;

        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        _input.PauseEvent -= TogglePauseMenu;
        _input.RestartLevelEvent -= OnRestartLevel;
        _input.LevelSelectorEvent -= OnOpenLevelSelectorScene;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode loadSceneMode)
    {
        if (scene.name == GameManager.LevelSelectorScene || scene.name == GameManager.MainMenuScene)
        {
            _canPauseInScene = false;
            DisablePauseMenu();
        }
        else
        {
            _canPauseInScene = true;
        }
    }

    public void OnRestartLevel()
    {
        GameManager.Instance.RestartLevel();
        DisablePauseMenu();
    }

    public void OnOpenLevelSelectorScene()
    {
        GameManager.Instance.OpenLevelSelectorScene();
        DisablePauseMenu();
    }

    public void DisablePauseMenu()
    {
        _pauseMenuGO.SetActive(false);
        GameManager.Instance.SetPause(false);
    }

    private void TogglePauseMenu()
    {
        if (_canPauseInScene == false)
        {
            return;
        }

        _pauseMenuGO.SetActive(!_pauseMenuGO.activeSelf);
        GameManager.Instance.SetPause(_pauseMenuGO.activeSelf);
    }
}
