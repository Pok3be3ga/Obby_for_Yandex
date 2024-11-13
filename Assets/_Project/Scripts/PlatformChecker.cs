using UnityEngine;
using YG;

public class PlatformChecker : MonoBehaviour
{
    public void CheckPlatform()
    {
        if(YandexGame.EnvironmentData.isDesktop == true)
        {
            gameObject.SetActive(false);
        }
        
    }
}
