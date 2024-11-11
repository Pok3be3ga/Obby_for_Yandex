using UnityEngine;

public class CheckPointSky : CheckPoint
{
    [SerializeField] private Material skyMaterial;
    public override void Trigger()
    {
        _active = true;
        base.Trigger();
        RenderSettings.skybox = skyMaterial;
    }
}