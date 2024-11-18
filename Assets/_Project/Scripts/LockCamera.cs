using UnityEngine;
using UnityEngine.UI;
using AdvancedController;
using UnityEngine.EventSystems;

public class LockCamera : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField] private CameraController _cameraController;
    private float _startCameraSpped;
    void Start()
    {
        _startCameraSpped = _cameraController.cameraSpeed;
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        _cameraController.cameraSpeed = 0f;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        _cameraController.cameraSpeed = _startCameraSpped;
    }
}
