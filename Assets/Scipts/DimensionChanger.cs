using UnityEngine;

public class DimensionChanger : MonoBehaviour
{
    private readonly KeyCode ChangeKey = KeyCode.F;

    [SerializeField] private DimensionController _worldController;

    private void Update()
    {
        if (Input.GetKeyUp(ChangeKey))
        {
            _worldController.Switch();
        }
    }
}
