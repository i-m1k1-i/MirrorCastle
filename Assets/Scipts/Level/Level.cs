using UnityEngine;
using UnityEngine.SceneManagement;
using YG;

public class Level : MonoBehaviour
{
    public const string LevelNamePrefix = "Level";

    [SerializeField] private int _levelNumber;

    public int LevelNumber => _levelNumber;

    private void Start()
    {
        _levelNumber = int.Parse(SceneManager.GetActiveScene().name.Replace(LevelNamePrefix, ""));
    }

    public void LoadNextLevel()
    {
        int nextLevelNumber = _levelNumber + 1;
        string nextLevelName = LevelNamePrefix + nextLevelNumber;

        bool nextLevelExists = SceneUtility.GetBuildIndexByScenePath(nextLevelName) != -1;

        if (nextLevelExists)
        {
            GameManager.Instance.UnlockLevel(nextLevelNumber);
            SceneManager.LoadScene(nextLevelName);
        }
        else
        {
            GameManager.Instance.LastLevelCompleted();
            SceneManager.LoadScene(GameManager.LevelSelectorScene);
        }

        YG2.InterstitialAdvShow();
    }
}
