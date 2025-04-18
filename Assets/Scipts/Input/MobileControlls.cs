using UnityEngine;
using YG;
using UnityEngine.SceneManagement;
using static UnityEngine.AudioSettings;

public class MobileControlls : MonoBehaviour
{
    private void Awake()
    {
        if (YG2.envir.isDesktop)
        {
            MobileControllsOff();
            Destroy(gameObject);
        }
        else
        {
            MobileControllsOn();
            DontDestroyOnLoad(gameObject);
        }

        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == GameManager.LevelSelectorScene || scene.name == GameManager.MainMenuScene)
        {
            MobileControllsOff();
        }
        else
        {
            MobileControllsOn();
        }
    }

    public void MobileControllsOff()
    {
        gameObject.SetActive(false);
    }

    public void MobileControllsOn()
    {
        gameObject.SetActive(true);
    }
}
