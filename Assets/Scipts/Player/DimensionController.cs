using UnityEngine;
public class DimensionController
{
    private IHasLayer _hasLayer;
    private DimensionLayers _currentDimension;

    public DimensionController(IHasLayer hasLayer, DimensionLayers layer)
    {
        _hasLayer = hasLayer;
        _currentDimension = layer;
    }

    public void Switch()
    {
        Debug.Log("Switch dimension");
        if (_currentDimension == DimensionLayers.MirrorWorld)
        {
            _currentDimension = DimensionLayers.RealWorld;
            _hasLayer.SetLayer(DimensionLayers.RealWorld);
        }
        else
        {
            _currentDimension = DimensionLayers.MirrorWorld;
            _hasLayer.SetLayer(DimensionLayers.MirrorWorld);
        }
    }
}
