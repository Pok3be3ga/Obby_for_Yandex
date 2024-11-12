using AdvancedController;
using AudioSystem;
using UnityEngine;
using YG;


public class PlayerRevert : MonoBehaviour
{
    [SerializeField] private float _yPositionRevert = -30f;
    [SerializeField] private float _force = 10f;
    [SerializeField] private SoundData _checkPointSound;
    [SerializeField] private SoundData _dieSound;

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
            SetTransform(_player.transform.localPosition, false);
        else
            RevertPlayer(false);
    }

    void Update()
    {
        if (gameObject.transform.position.y < _yPositionRevert)
        {
            RevertPlayer(true);
        }
    }

    public void RevertPlayer(bool playSound)
    {
        if (playSound)
            PlaySound(_dieSound);

        _player.transform.position = new(YandexGame.savesData.CurrentCheckPointX,
            YandexGame.savesData.CurrentCheckPointY, YandexGame.savesData.CurrentCheckPointZ);
    }

    public void SetTransform(Vector3 transform, bool playSound)
    {
        YandexGame.savesData.CurrentCheckPointX = transform.x;
        YandexGame.savesData.CurrentCheckPointY = transform.y;
        YandexGame.savesData.CurrentCheckPointZ = transform.z;
        YandexGame.SaveProgress();

        if (playSound)
            PlaySound(_checkPointSound);
    }

    private void PlaySound(SoundData soundData)
    {
        if (SoundManager.Instance != null && soundData != null)
        {
            SoundBuilder soundBuilder = SoundManager.Instance.CreateSoundBuilder();
            soundBuilder.WithPosition(transform.position)
                         .WithRandomPitch()
                         .Play(soundData);
        }
        else
        {
            Debug.LogWarning("SoundManager или SoundData не инициализированы !");
        }
    }

    public void UpPlayer()
    {
        _playerController.OnJumpStart();
        _rigidbody.AddRelativeForce(Vector3.up * _force + Vector3.right, ForceMode.Impulse);
    }
}
