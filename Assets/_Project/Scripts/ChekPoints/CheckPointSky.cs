using UnityEngine;

public class CheckPointSky : CheckPoint
{
    [SerializeField] private Material skyMaterial;
    public override void Trigger()
    {
        base.Trigger();
        RenderSettings.skybox = skyMaterial;
    }
}