using UnityEngine;
using UnityEngine.SceneManagement;

public class Level : MonoBehaviour
{
    private static int _firstLevelIndex = 1;

    public static void StartFirstLevel()
    {
        SceneManager.LoadScene(_firstLevelIndex);
    }

    public static void End()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.buildIndex + 1);
    }

    public static void Restart()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.buildIndex);
    }
}
