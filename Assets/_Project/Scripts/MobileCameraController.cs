using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class MobileCameraController : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public bool Pressed = false;
    public int FingerID;

    public void OnPointerDown(PointerEventData eventData)
    {
        Pressed = true;
        FingerID = eventData.pointerId;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        Pressed = false;
    }
}
