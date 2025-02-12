using UnityEngine;
using UnityEngine.Events;

public class CheckPoint : MonoBehaviour
{
    public UnityEvent _event;
    private PlayerRevert _player;
    private GameManager _gameManager;
    public bool _active = false;
    public void Start()
    {
        //_gameManager = FindObjectOfType<GameManager>();
        _player = FindFirstObjectByType<PlayerRevert>();
    }
    public virtual void OnTriggerEnter(Collider other)
    {
        Trigger();
    }
    public virtual void Trigger()
    {
        if(_active == false)
        {
            _player.SetTransform(gameObject.transform.position + Vector3.up, true);
            _active = true;
        }
        else
        {

        }
        _event.Invoke();
    }
}
