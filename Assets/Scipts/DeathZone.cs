using UnityEngine;
using UnityEngine.Events;

public class DeathZone : MonoBehaviour
{
    public static event UnityAction playerDied;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent<Player>(out Player player))
        {
            playerDied?.Invoke();
            GameManager.Instance.RestartLevel();
        }
    }
}
