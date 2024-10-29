using AdvancedController;
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem.XR;

public class PlayerRevert : MonoBehaviour
{
    [SerializeField] private float _yPositionRevert = -30f;
    [SerializeField] private float _force = 10f;
    private GameObject _player;
    private PlayerController _playerController;
    private PlayerMover _playerMover;
    private Rigidbody _rigidbody;
    private Vector3 _currentCheckPoint;
    private Animator _controller;
    void Start()
    {
        _player = gameObject;
        _playerController = _player.GetComponent<PlayerController>();
        _playerMover = _player.GetComponent<PlayerMover>();
        _rigidbody = _player.GetComponent<Rigidbody>();
        _controller = gameObject.GetComponentInChildren<Animator>();
        SetTransform(_player.transform.localPosition);
    }
    void Update()
    {
        if(gameObject.transform.position.y < _yPositionRevert)
        {
            RevertPlayer();
        }
    }
    public void RevertPlayer()
    {
        _player.transform.position = _currentCheckPoint;
    }
    public void SetTransform(Vector3 transform)
    {
        _currentCheckPoint = transform;
    }
    public void UpPlayer()
    {
        _playerController.OnJumpStart();
        //_playerMover.SetVelocity(Vector3.up * _force);
        _rigidbody.AddRelativeForce(Vector3.up * _force + Vector3.right, ForceMode.Impulse);
    }
}
