using UnityEngine;
using YG;
using UnityEngine.SceneManagement;

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
        }

        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    public void Disable()
    {
        gameObject.SetActive(false);
    }

    public void Enable()
    {
        gameObject.SetActive(true);
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
