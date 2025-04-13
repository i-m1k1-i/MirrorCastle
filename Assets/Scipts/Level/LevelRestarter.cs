using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelRestarter : MonoBehaviour
{
    [SerializeField] private KeyCode _restartKeyCode = KeyCode.R;

    private void Update()
    {
        if (Input.GetKeyDown(_restartKeyCode))
        {
            Scene currentScene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(currentScene.buildIndex);
        }
    }
}