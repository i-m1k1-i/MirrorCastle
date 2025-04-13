using UnityEngine;
using UnityEngine.SceneManagement;
using YG;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

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

    public void LoadLevelSelector()
    {
        SceneManager.LoadScene("LevelSelector");
    }
}
