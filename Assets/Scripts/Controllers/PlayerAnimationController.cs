using System;
using Platformer.Data;
using Platformer.Interfaces;
using Platformer.Views;

namespace Platformer.Controllers
{
    public class PlayerAnimationController : IUpdate, ICleanup
    {
        private readonly PlayerConfig _playerConfig;
        private readonly CharacterView _player;
        private readonly SpriteAnimator _animator;

        public PlayerAnimationController(PlayerConfig playerConfig, CharacterView player)
        {
            _playerConfig = playerConfig;
            _player = player;
            _animator = new SpriteAnimator(playerConfig.spriteAnimationsConfig);
            
            player.OnStateChange += ChangeAnimation;
        }

        private void ChangeAnimation(PlayerState playerState)
        {
            _animator.StartAnimation(_player.SpriteRenderer, GetAnimState(playerState), true, _playerConfig.animationSpeed);
        }

        private AnimState GetAnimState(PlayerState playerState)
        {
            return playerState switch
            {
                PlayerState.Run => AnimState.Run,
                PlayerState.Idle => AnimState.Idle,
                PlayerState.Jump => AnimState.Jump,
                _ => throw new ArgumentOutOfRangeException(nameof(playerState), playerState, null)
            };
        }
        
        public void Update(float deltaTime)
        {
            _animator.Update(deltaTime);
        }

        public void Cleanup()
        {
            _animator.Cleanup();
        }
    }
}