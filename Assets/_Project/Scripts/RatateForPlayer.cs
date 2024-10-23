using UnityEngine;

public class RatateForPlayer : MonoBehaviour
{
    private GameObject _player;
    [SerializeField] private bool _look;
    private void Start()
    {
        _player = FindObjectOfType<PlayerRevert>().gameObject;
    }
    void Update()
    {
        if(_look)
        {
            RotatePlayer();
        }
    }
    private void RotatePlayer()
    {
        Vector3 direction = _player.transform.position - transform.position;
        Quaternion rotation = Quaternion.LookRotation(direction);
        transform.rotation = rotation;
    }
    public void Look(bool look)
    {
        _look = look;
    }
}
