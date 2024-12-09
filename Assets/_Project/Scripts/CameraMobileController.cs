using UnityEngine;

public class CameraMobileController : MonoBehaviour
{
    [SerializeField] float _sens = 2f;
    [SerializeField] float _sensPanelRotate = 1f;
    [SerializeField] float _maxYAngle = 80;
     float _rotationX = 0f;
     float _rotationY = 0f;

    [SerializeField] int _coefX = 1;
    [SerializeField] int _coefY = 1;
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
                        mouseX = touch.deltaPosition.x * _sensPanelRotate * _coefX;
                        mouseY = touch.deltaPosition.y * -_sensPanelRotate * _coefY;
                    }
                    if (touch.phase == TouchPhase.Stationary)
                    {
                        mouseX = 0f;
                        mouseY = 0f;
                    }
                }
            }
        }

        _rotationX -= mouseY * _sens;
        _rotationX = Mathf.Clamp(_rotationX, -_maxYAngle, _maxYAngle);
        _rotationY += mouseX * _sens;
        transform.localRotation = Quaternion.Euler(_rotationX, _rotationY, 0.0f);
    }
}
