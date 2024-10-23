using UnityEngine;
using UnityEngine.Events;

public class CheckPoint : MonoBehaviour
{
    public UnityEvent _event;
    private PlayerRevert _player;
    public void Start()
    {
        _player = FindObjectOfType<PlayerRevert>();
    }
    public void OnTriggerEnter(Collider other)
    {
        Trigger();
    }
    public virtual void Trigger()
    {
        _player.SetTransform(gameObject.transform.position);
        _event.Invoke();
    }
}
