using UnityEngine;

[RequireComponent(typeof(Move), typeof(DimensionChanger))]
public class Player : MonoBehaviour
{
    private Move _move;


    private void Start()
    {
        _move = GetComponent<Move>();
    }

    public void SetLayer(DimensionLayers layer)
    {
        gameObject.layer = (int)layer;
        _move.Feet.gameObject.layer = (int)layer;
    }
}
