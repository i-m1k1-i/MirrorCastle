using UnityEngine;
using UnityEngine.SceneManagement;

public class UIInteractionManager : MonoBehaviour
{
    [SerializeField] private InputReader _input;
    [SerializeField] private GameObject _pauseMenuGO;
    [SerializeField] private GameObject _levelEndMenuGO;

    private bool _pauseableScene = false;

    private void OnEnable()
    {
        _input.PauseEvent += TogglePauseMenu;

        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        _input.PauseEvent -= TogglePauseMenu;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode loadSceneMode)
    {
        if (scene.name == GameManager.LevelSelectorScene || scene.name == GameManager.MainMenuScene)
        {
            _pauseableScene = false;
            DisablePauseMenu();
        }
        else
        {
            _pauseableScene = true;
        }
    }

    // Used in ui button OnClick
    public void RestartLevel()
    {
        GameManager.Instance.RestartLevel();

        DisablePauseMenu();
        DisableNextLevelMenu();
    }

    // Used in ui button OnClick
    public void OpenLevelSelectorScene()
    {
        GameManager.Instance.OpenLevelSelectorScene();

        DisablePauseMenu();
        DisableNextLevelMenu();
    }

    // Used in ui button OnClick
    public void HandleNextLevelPressed()
    {
        Level level = FindAnyObjectByType<Level>();
        level.LoadNextLevel();
        DisableNextLevelMenu();
    }

    public void EnableNextLevelMenu()
    {
        _levelEndMenuGO.SetActive(true);
    }

    private void DisableNextLevelMenu()
    {
        _levelEndMenuGO.SetActive(false);
    }

    private void DisablePauseMenu()
    {
        _pauseMenuGO.SetActive(false);
        GameManager.Instance.SetPause(false);
    }

    private void TogglePauseMenu()
    {
        if (_pauseableScene == false)
        {
            return;
        }

        _pauseMenuGO.SetActive(!_pauseMenuGO.activeSelf);

        GameManager.Instance.SetPause(_pauseMenuGO.activeSelf);
    }
}