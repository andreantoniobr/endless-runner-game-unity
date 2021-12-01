using System.Collections;
using UnityEngine;

public enum OverlayName
{
    MainHud,
    Pause,
    Start,
    Settings,
}

[System.Serializable]
public struct Overlay
{
    public OverlayName overlayName;
    public GameObject overlayObject;
}

public class HUDManager : MonoBehaviour
{
    [SerializeField] private Overlay[] overlays;

    public void SetActiveOverlay(OverlayName overlayName)
    {
        foreach (Overlay overlay in overlays)
        {
            bool isActive = false;
            if (overlay.overlayName == overlayName)
            {
                isActive = true;
            }
            SetActiveObject(isActive, overlay.overlayObject);
        }
    }

    private void SetActiveObject(bool isActive, GameObject overlayObject)
    {
        if (overlayObject && overlayObject.activeSelf != isActive)
        {
            overlayObject.SetActive(isActive);
        }
    }
}
