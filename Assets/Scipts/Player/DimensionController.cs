using UnityEngine;

public class DimensionController : MonoBehaviour
{
    [SerializeField] private Player _player;

    private DimensionLayers _currentDimension;


    private void Awake()
    {
        _player = GetComponent<Player>();
        _currentDimension = DimensionLayers.RealWorld;
    }

    public void Switch()
    {
        if (_currentDimension == DimensionLayers.MirrorWorld)
        {
            _currentDimension = DimensionLayers.RealWorld;
            _player.SetLayer(DimensionLayers.RealWorld);
        }
        else
        {
            _currentDimension = DimensionLayers.MirrorWorld;
            _player.SetLayer(DimensionLayers.MirrorWorld);
        }
        // тестовое изменение 3
    }
}
