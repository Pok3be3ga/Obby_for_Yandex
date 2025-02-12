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
            //        Debug.Log("������ ���������. ������� 'C', ��� �� ��������");
            //    else
            //        Debug.Log("������ ��������. ������� 'C', ��� �� ���������");
            //}
            RotateCamera(Input.GetAxisRaw("Mouse X"), -Input.GetAxisRaw("Mouse Y"));
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
