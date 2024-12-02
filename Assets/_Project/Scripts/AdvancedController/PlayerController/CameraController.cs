using Sirenix.OdinInspector;
using UnityEngine;
using UnityUtils;

namespace AdvancedController
{
    public class CameraController : MonoBehaviour
    {
        #region Fields
        float currentXAngle;
        float currentYAngle;

        [Range(0f, 90f)] public float upperVerticalLimit = 35f;
        [Range(0f, 90f)] public float lowerVerticalLimit = 35f;

        public float cameraSpeed = 5f;
        public bool smoothCameraRotation;
        [Range(1f, 50f)] public float cameraSmoothingFactor = 25f;

        private float _xEuler;
        Transform tr;
        Camera cam;
        //[SerializeField, Required] InputReader input;
        [SerializeField] MobileCameraController mobileCameraController;
        private bool _isRotationLocked = false;
        #endregion

        public Vector3 GetUpDirection() => tr.up;
        public Vector3 GetFacingDirection() => tr.forward;

        void Awake()
        {
            tr = transform;
            cam = GetComponentInChildren<Camera>();

            currentXAngle = tr.localRotation.eulerAngles.x;
            currentYAngle = tr.localRotation.eulerAngles.y;
        }

        void LateUpdate()
        {
            //if (Input.GetKeyDown(KeyCode.C))
            //{
            //    _isRotationLocked = !_isRotationLocked;
            //    if (_isRotationLocked)
            //        Debug.Log("Камеры выключена. Нажмите 'C', что бы включить");
            //    else
            //        Debug.Log("Камеры включена. Нажмите 'C', что бы выключить");
            //}
            if (!_isRotationLocked)
                RotateCamera(Input.GetAxisRaw("Mouse X"), -Input.GetAxisRaw("Mouse Y"));


            if (mobileCameraController.Pressed)
            {
                _isRotationLocked = true;
                foreach (Touch touch in Input.touches)
                {
                    if ((touch.fingerId == mobileCameraController.FingerID))
                    {
                        if (touch.phase == TouchPhase.Moved)
                        {
                            RotateCamera(touch.deltaPosition.y, -touch.deltaPosition.x);
                        }
                        if (touch.phase == TouchPhase.Stationary)
                        {
                            RotateCamera(0, 0);
                        }
                    }
                }
            }
            else
                _isRotationLocked = false;
        }

        void RotateCamera(float horizontalInput, float verticalInput)
        {
            if (smoothCameraRotation)
            {
                horizontalInput = Mathf.Lerp(0, horizontalInput, Time.deltaTime * cameraSmoothingFactor);
                verticalInput = Mathf.Lerp(0, verticalInput, Time.deltaTime * cameraSmoothingFactor);
            }

            currentXAngle += verticalInput * cameraSpeed * Time.deltaTime;
            currentYAngle += horizontalInput * cameraSpeed * Time.deltaTime;

            currentXAngle = Mathf.Clamp(currentXAngle, -upperVerticalLimit, lowerVerticalLimit);

            tr.localRotation = Quaternion.Euler(currentXAngle, currentYAngle, 0);
        }
    }
}
