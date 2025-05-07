using UnityEngine;

[RequireComponent(typeof(Camera))]
public class FixedAspectRatio : MonoBehaviour
{
    public enum ScreenHalf { Top, Bottom }

    [SerializeField] private ScreenHalf half = ScreenHalf.Top;
    [SerializeField] private Vector2 targetResolution = new Vector2(16, 9);

    private Camera _camera;
    private int _lastScreenWidth;
    private int _lastScreenHeight;

    private void Start()
    {
        _camera = GetComponent<Camera>();
        UpdateViewport();
    }

    private void Update()
    {
        if (Screen.width != _lastScreenWidth || Screen.height != _lastScreenHeight)
        {
            UpdateViewport();
        }
    }

    private void UpdateViewport()
    {
        _lastScreenWidth = Screen.width;
        _lastScreenHeight = Screen.height;

        float targetAspect = targetResolution.x / targetResolution.y;
        float screenAspect = (float)Screen.width / (float)Screen.height;
        float scaleHeight = screenAspect / targetAspect;

        Rect rect;

        if (scaleHeight < 1.0f)
        {
            rect = new Rect(0f, 0f, 1f, scaleHeight);
            rect.y = (1f - scaleHeight) / 2f;

            rect.height *= 0.5f;
            rect.y += (half == ScreenHalf.Top) ? 0.5f * scaleHeight : 0f;
        }
        else
        {
           float scaleWidth = 1f / scaleHeight;

            rect = new Rect(0f, 0f, scaleWidth, 1f);
            rect.x = (1f - scaleWidth) / 2f;

            rect.height = 0.5f;
            rect.y = (half == ScreenHalf.Top) ? 0.5f : 0f;
        }

        _camera.rect = rect;
    }
}
