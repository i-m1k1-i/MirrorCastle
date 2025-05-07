using UnityEngine;
using YG;

public class ObjectsForDevice : MonoBehaviour
{
    [SerializeField] private GameObject[] _mobileObjects;
    [SerializeField] private GameObject[] _desktopObjects;

    private void Awake()
    {
        if (IsHandled(YG2.envir.device))
        {
            foreach (GameObject obj in _desktopObjects)
            {
                obj.SetActive(false);
            }

            foreach (GameObject obj in _mobileObjects)
            {
                obj.SetActive(true);
            }
        }
        else
        {
            foreach (GameObject obj in _desktopObjects)
            {
                obj.SetActive(true);
            }

            foreach (GameObject obj in _mobileObjects)
            {
                obj.SetActive(false);
            }
        }
    }
    private bool IsHandled(YG2.Device device)
    {
        return device == YG2.Device.Mobile || device == YG2.Device.Tablet;
    }
}
