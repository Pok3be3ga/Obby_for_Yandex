using UnityEngine;
public class CheckPointEyes : CheckPoint
{
    [SerializeField] private RatateForPlayer[] _eyes;
    [SerializeField] private bool OnOff;
    public override void Trigger()
    {
        base.Trigger();
        for (int i = 0; i < _eyes.Length; i++)
        {
            _eyes[i].Look(OnOff);
        }
    }
}
