using UnityEngine;

public class PlatformAttachment : MonoBehaviour
{
    private Transform _basicParent;
    private Transform _newParent;

    private void Start()
    {
        _basicParent = transform.parent;
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        Debug.Log("Triiger enter: " + collider);

        if (collider.TryGetComponent<MovingPlatform>(out MovingPlatform platform) == false)
        {
            return;
        }

        transform.parent = _newParent = platform.transform;

        Debug.Log("Attached");
    }

    private void OnTriggerExit2D(Collider2D collider)
    {
        Debug.Log("Triiger exit: " + collider);

        if (collider.TryGetComponent<MovingPlatform>(out MovingPlatform _) == false)
        {
            return;
        }
        if (_newParent == null)
        {
            return;
        }

        transform.parent = _basicParent;
        _newParent = null;
    }
}
