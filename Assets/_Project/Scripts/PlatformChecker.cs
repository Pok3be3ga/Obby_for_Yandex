using AdvancedController;
using UnityEngine;
using YG;

public class PlatformChecker : MonoBehaviour
{
    [SerializeField] private CameraController _cameraController;
    [SerializeField] private CameraDistanceRaycaster _cameraDistanceRaycaster;
    [SerializeField] private CameraMobileController _cameraMobileController;

    [SerializeField] private bool _debug;
    public void CheckPlatform()
    {
        if (_debug == false)
        {
            if (YandexGame.EnvironmentData.isDesktop == true)
            {
                gameObject.SetActive(false);
                _cameraController.enabled = true;
                _cameraDistanceRaycaster.enabled = true;

                _cameraMobileController.enabled = false;
            }
            else
            {
                _cameraController.enabled = false;
                _cameraDistanceRaycaster.enabled = false;

                _cameraMobileController.enabled = true;
            }
        }
        else
        {
            _cameraController.enabled = false;
            _cameraDistanceRaycaster.enabled = false;

            _cameraMobileController.enabled = true;
        }
    }
}
