using UnityEngine;
using UnityEngine.SceneManagement;

public class UIInteractionManager : MonoBehaviour
{
    [SerializeField] private InputReader _input;

    [SerializeField] private GameObject _pauseMenuGO;
    [SerializeField] private GameObject _levelEndMenuGO;
    [SerializeField] private GameObject _deathMenuGO;

    private bool _pauseableScene = false;

    private void OnEnable()
    {
        _input.PauseEvent += TogglePauseMenu;

        SceneManager.sceneLoaded += OnSceneLoaded;
        DeathZone.PlayerDied += EnableDeathMenu;
        Level.LevelCompleted += EnableNextLevelMenu;
    }

    private void OnDisable()
    {
        _input.PauseEvent -= TogglePauseMenu;

        SceneManager.sceneLoaded -= OnSceneLoaded;
        DeathZone.PlayerDied -= EnableDeathMenu;
        Level.LevelCompleted -= EnableNextLevelMenu;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode loadSceneMode)
    {
        if (scene.name == GameManager.LevelSelectorScene || scene.name == GameManager.MainMenuScene)
        {
            _pauseableScene = false;
        }
        else
        {
            _pauseableScene = true;
        }

        DisablePauseMenu();
        DisableNextLevelMenu();
        DisableDeathMenu();
    }

    // Used in ui button OnClick
    public void RestartLevel()
    {
        GameManager.Instance.RestartLevel();
    }

    // Used in ui button OnClick
    public void OpenLevelSelectorScene()
    {
        GameManager.Instance.OpenLevelSelectorScene();
    }

    // Used in ui button OnClick
    public void LoadNextLevel()
    {
        Level level = FindAnyObjectByType<Level>();
        level.LoadNextLevel();
    }

    private void EnableNextLevelMenu()
    {
        _levelEndMenuGO.SetActive(true);
        GameManager.Instance.SetPause(true);
    }

    private void DisableNextLevelMenu()
    {
        _levelEndMenuGO.SetActive(false);
    }

    private void EnableDeathMenu()
    {
        _deathMenuGO.SetActive(true);
    }

    private void DisableDeathMenu()
    {
        _deathMenuGO.SetActive(false);
    }


    private void TogglePauseMenu()
    {
        if (_levelEndMenuGO.activeSelf || _deathMenuGO.activeSelf)
        {
            return;
        }
        if (_pauseableScene == false)
        {
            return;
        }

        _pauseMenuGO.SetActive(!_pauseMenuGO.activeSelf);

        GameManager.Instance.SetPause(_pauseMenuGO.activeSelf);
    }

    private void DisablePauseMenu()
    {
        _pauseMenuGO.SetActive(false);
        GameManager.Instance.SetPause(false);
    }
}