using UnityEngine;

public class DimensionController : MonoBehaviour
{
    [SerializeField] private Player _player;
    // [SerializeField] private Canvas _turbidity;
    // [SerializeField] private Camera _realWorldCamera, _mirrorWorldCamera;

    private DimensionLayers _currentWorld;


    private void Start()
    {
        _currentWorld = DimensionLayers.RealWorld;
    }

    public void Switch()
    {
        if (_currentWorld == DimensionLayers.MirrorWorld)
        {
            // SetTurbidityCamera(_mirrorWorldCamera);
            _currentWorld = DimensionLayers.RealWorld;
            _player.SetLayer(DimensionLayers.RealWorld);
        }
        else
        {
            // SetTurbidityCamera(_realWorldCamera);
            _currentWorld = DimensionLayers.MirrorWorld;
            _player.SetLayer(DimensionLayers.MirrorWorld);
        }
    }

    //private void SetTurbidityCamera(Camera camera)
    //{
    //    _turbidity.worldCamera = _currentCamera = camera;
    //}
}
