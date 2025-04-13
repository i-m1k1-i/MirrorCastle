using UnityEngine;
using UnityEngine.SceneManagement;

public class Level : MonoBehaviour
{
    public const string NamePrefix = "Level";
    public const string LevelSelectorName = "LevelSelector";

    [SerializeField] private int _levelNumber;

    public int LevelNumber => _levelNumber;

    private void Start()
    {
        _levelNumber = int.Parse(SceneManager.GetActiveScene().name.Replace(NamePrefix, ""));
        GameManager.Instance.UnlockLevel(_levelNumber);
    }

    public void LoadNextLevel()
    {
        int nextLevelNumber = _levelNumber + 1;
        string nextLevelName = NamePrefix + nextLevelNumber;

        bool sceneExist = (SceneUtility.GetBuildIndexByScenePath("path or name of the scene") != -1);

        if (sceneExist)
        {
            SceneManager.LoadScene(nextLevelName);
        }
        else
        {
            SceneManager.LoadScene(LevelSelectorName);
        }   
    }
}
