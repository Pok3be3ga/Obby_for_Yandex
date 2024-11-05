using AdvancedController;
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem.XR;
using YG;

public class PlayerRevert : MonoBehaviour
{
    [SerializeField] private float _yPositionRevert = -30f;
    [SerializeField] private float _force = 10f;
    private GameObject _player;
    private PlayerController _playerController;
    private PlayerMover _playerMover;
    private Rigidbody _rigidbody;
    private Animator _controller;
    void Start()
    {
        _player = gameObject;
        _playerController = _player.GetComponent<PlayerController>();
        _playerMover = _player.GetComponent<PlayerMover>();
        _rigidbody = _player.GetComponent<Rigidbody>();
        _controller = gameObject.GetComponentInChildren<Animator>();        

        if (YandexGame.savesData.CurrentCheckPointX == 0f)
            SetTransform(_player.transform.localPosition);
        else
            RevertPlayer();
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
        _player.transform.position = new(YandexGame.savesData.CurrentCheckPointX, 
            YandexGame.savesData.CurrentCheckPointY, YandexGame.savesData.CurrentCheckPointZ);
    }
    public void SetTransform(Vector3 transform)
    {
        YandexGame.savesData.CurrentCheckPointX = transform.x;
        YandexGame.savesData.CurrentCheckPointY = transform.y;
        YandexGame.savesData.CurrentCheckPointZ = transform.z;
        YandexGame.SaveProgress();
    }
    public void UpPlayer()
    {
        _playerController.OnJumpStart();
        //_playerMover.SetVelocity(Vector3.up * _force);
        _rigidbody.AddRelativeForce(Vector3.up * _force + Vector3.right, ForceMode.Impulse);
    }
}
