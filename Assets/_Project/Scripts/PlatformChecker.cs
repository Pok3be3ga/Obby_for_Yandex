using AdvancedController;
using UnityEngine;
using YG;

public class PlatformChecker : MonoBehaviour
{
    [SerializeField] private CameraController _cameraController;
    public void CheckPlatform()
    {
        if (YandexGame.EnvironmentData.isDesktop == true)
        {
            gameObject.SetActive(false);
            _cameraController.Loked(false);
        }
        else
            _cameraController.Loked(true);
        
    }
}
