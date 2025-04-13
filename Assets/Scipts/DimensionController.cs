using UnityEngine;

public class DimensionController : MonoBehaviour
{
    [SerializeField] private Player _player;
    // [SerializeField] private Canvas _turbidity;
    // [SerializeField] private Camera _realWorldCamera, _mirrorWorldCamera;
    private readonly KeyCode ChangeKey = KeyCode.F;

    private DimensionLayers _currentDimension;


    private void Start()
    {
        _currentDimension = DimensionLayers.RealWorld;
    }

    private void Update()
    {
        if (Input.GetKeyUp(ChangeKey))
        {
            Switch();
        }
    }

    private void Switch()
    {
        if (_currentDimension == DimensionLayers.MirrorWorld)
        {
            // SetTurbidityCamera(_mirrorWorldCamera);
            _currentDimension = DimensionLayers.RealWorld;
            _player.SetLayer(DimensionLayers.RealWorld);
        }
        else
        {
            // SetTurbidityCamera(_realWorldCamera);
            _currentDimension = DimensionLayers.MirrorWorld;
            _player.SetLayer(DimensionLayers.MirrorWorld);
        }
    }

    //private void SetTurbidityCamera(Camera camera)
    //{
    //    _turbidity.worldCamera = _currentCamera = camera;
    //}
}
