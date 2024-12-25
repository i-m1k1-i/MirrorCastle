using UnityEngine;

public class LevelRestarter : MonoBehaviour
{
    private KeyCode _restartKeyCode = KeyCode.R;

    private void Update()
    {
        if (Input.GetKeyDown(_restartKeyCode))
        {
            Level.Restart();
        }
    }
}