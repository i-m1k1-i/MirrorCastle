using UnityEngine;
using UnityEngine.Events;

public class DeathZone : MonoBehaviour
{
    public static event UnityAction PlayerDied;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent<Player>(out Player player))
        {
            PlayerDied?.Invoke();
            GameManager.Instance.RestartLevel();
        }
    }
}
