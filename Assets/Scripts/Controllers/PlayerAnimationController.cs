using Platformer.Data;
using Platformer.Interfaces;
using Platformer.Views;

namespace Platformer.Controllers
{
    public class PlayerAnimationController : IUpdate, ICleanup
    {
        private SpriteAnimator _animator;

        public PlayerAnimationController(PlayerConfig config, CharacterView player)
        {
            _animator = new SpriteAnimator(config.spriteAnimationsConfig);
            
            _animator.StartAnimation(player.SpriteRenderer, AnimState.Idle, true, config.animationSpeed);
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