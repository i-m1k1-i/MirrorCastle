using UnityEngine;

public class ExitButton : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.TryGetComponent<Player>(out Player _))
        {
            Debug.Log("Quit");
            Application.Quit();
        }
    }
}
