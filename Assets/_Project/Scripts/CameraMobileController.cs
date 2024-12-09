using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMobileController : MonoBehaviour
{
    [SerializeField] float _sens = 2f;
    [SerializeField] float _sensPanelRotate = 1f;
    [SerializeField] float _maxYAngle = 80;
    [SerializeField] float _rotationX = 0f;
    [SerializeField] float _rotationY = 0f;

    [SerializeField] Vector2 _debugPosition;
    [SerializeField] TouchChecker _touchChecker;

    private void Update()
    {
        float mouseX = 0f;
        float mouseY = 0f;

        if (_touchChecker.Pressed)
        {
            foreach(Touch touch in Input.touches)
            {
                if (touch.fingerId == _touchChecker.FingerID)
                {
                    if (touch.phase == TouchPhase.Moved)
                    {
                        _debugPosition = touch.position;
                        mouseY = touch.deltaPosition.y * _sensPanelRotate;
                        mouseX = touch.deltaPosition.x * _sensPanelRotate;
                    }
                    if (touch.phase == TouchPhase.Stationary)
                    {
                        mouseY = 0f;
                        mouseX = 0f;
                    }
                }
            }
        }

        _rotationX -= mouseY * _sens;
        _rotationX = Mathf.Clamp(_rotationX, -_maxYAngle, _maxYAngle);
        _rotationY -= mouseX * _sens;
        transform.localRotation = Quaternion.Euler(_rotationX, _rotationY, 0.0f);
    }
}
