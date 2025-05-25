using UnityEngine;


[RequireComponent(typeof(BoxCollider2D))]
public class LevelEndTrigger : MonoBehaviour
{
    private void Start()
    {
        BoxCollider2D collider = GetComponent<BoxCollider2D>();
        collider.isTrigger = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Player>(out Player _))
        {
            Level level = FindAnyObjectByType<Level>();
            GameManager.Instance.UnlockLevel(level.LevelNumber + 1);

            UIInteractionManager uiManager = FindAnyObjectByType<UIInteractionManager>();
            uiManager.EnableNextLevelMenu();
        }
    }
}
