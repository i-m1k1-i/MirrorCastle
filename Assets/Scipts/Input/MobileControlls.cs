using UnityEngine;
using UnityEngine.SceneManagement;
using YG;

public class MobileControlls : MonoBehaviour
{
    private void Awake()
    {
        if (YG2.envir.isDesktop)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
            SceneManager.sceneLoaded += OnSceneLoaded;
        }
    }

    private void OnDestroy()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void Enable()
    {
        gameObject.SetActive(true);
    }

    private void Disable()
    {
        gameObject.SetActive(false);
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == GameManager.LevelSelectorScene || scene.name == GameManager.MainMenuScene)
        {
            Disable();
        }
        else
        {
            Enable();
        }
    }
}
