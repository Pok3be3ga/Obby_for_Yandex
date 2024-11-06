using AudioSystem;
using UnityEngine;

namespace AdvancedController
{
    [RequireComponent(typeof(PlayerController))]
    public class AnimationController : MonoBehaviour
    {
        [SerializeField] private SoundData _jumpSound;

        private PlayerController _controller;
        private Animator _animator;
        private readonly int _speedHash = Animator.StringToHash("Speed");
        private readonly int _isJumpingHash = Animator.StringToHash("IsJumping");

        private void Start()
        {
            _controller = GetComponent<PlayerController>();
            _animator = GetComponentInChildren<Animator>();

            _controller.OnJump += HandleJump;
            _controller.OnLand += HandleLand;
        }

        private void Update()
        {
            _animator.SetFloat(_speedHash, _controller.GetMovementVelocity().magnitude);
        }

        private void HandleJump(Vector3 momentum)
        {
            _animator.SetBool(_isJumpingHash, true);
            PlaySound(_jumpSound);
        }

        private void HandleLand(Vector3 momentum)
        {
            _animator.SetBool(_isJumpingHash, false);
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
    }
}