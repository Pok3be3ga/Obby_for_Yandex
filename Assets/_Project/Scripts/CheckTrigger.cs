
using UnityEngine;

public class CheckTrigger : CheckPoint
{
    public override void OnTriggerEnter(Collider other)
    {
        OnlyTrigger();
    }
    public void OnlyTrigger()
    {
        _event.Invoke();
    }
}
