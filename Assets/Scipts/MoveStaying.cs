using UnityEngine;

public class MoveStaying : MonoBehaviour
{
    private Transform _previousParent;
    private Player _player;

    private void OnTriggerEnter2D(Collider2D collider)
    {
        Debug.Log("Triiger enter: " + collider);
        if (collider.TryGetComponent<Feet>(out Feet feet) == false)
        {
            return;
        }
        _player = feet.transform.parent.GetComponent<Player>();
        _previousParent = _player.transform.parent;
        _player.transform.parent = transform;
        Debug.Log(12);
    }

    private void OnTriggerExit2D(Collider2D collider)
    {
        Debug.Log("Triiger exit: " + collider) ;
        if (collider.TryGetComponent<Feet>(out Feet feet) == false)
        {
            return;
        }
        if (_player == null)
        { 
            return; 
        }

        _player.transform.parent = _previousParent;
        _player = null;
        _previousParent = null;
    }
}
