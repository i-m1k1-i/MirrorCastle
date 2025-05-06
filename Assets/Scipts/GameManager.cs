using UnityEngine;
using UnityEngine.SceneManagement;
using YG;

public class GameManager : MonoBehaviour
{
    public const string LevelSelectorScene = "LevelSelector";
    public const string MainMenuScene = "Menu";

    public static GameManager Instance;

    [SerializeField] private BackgroundMusic _backgroundMusic;
    [SerializeField] private InputReader _input;

    public bool PlayGameCompletedAnimation { get; private set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void UnlockLevel(int level)
    {
        if (YG2.saves.UnlockedLevel < level)
        {
            YG2.saves.UnlockedLevel = level;
            YG2.SaveProgress();
        }
    }

    public void RestartLevel()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.buildIndex);
    }

    public void OpenLevelSelectorScene()
    {
        SceneManager.LoadScene(LevelSelectorScene);
    }

    public void LastLevelCompleted()
    {
        PlayGameCompletedAnimation = true;
    }

    public void SetPause(bool pause)
    {
        if (pause)
        {
            _backgroundMusic.Pause();
            _input.DisablePlayerInput();
        }
        else
        {
            _backgroundMusic.UnPause();
            _input.EnablePlayerInput();
        }
    }
}
