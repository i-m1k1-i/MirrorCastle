using UnityEngine;
using YG;

public class ObjectForDevice : MonoBehaviour
{
    [SerializeField] private GameObject[] objectsToDisable;
    [SerializeField] private YG2.Device _objectsDeviceType;

    private void Awake()
    {
        if (YG2.envir.device == _objectsDeviceType
            || IsHandled(YG2.envir.device) == IsHandled(_objectsDeviceType))
        {
            foreach (GameObject obj in objectsToDisable)
            {
                obj.SetActive(false);
            }
        }
        else
        {
            foreach (GameObject obj in objectsToDisable)
            {
                obj.SetActive(true);
            }
        }
    }

    private bool IsHandled(YG2.Device device)
    {
        return device == YG2.Device.Mobile || device == YG2.Device.Tablet;
    }
}
