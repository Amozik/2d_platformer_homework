using System.Collections.Generic;
using Platformer.Data;
using Platformer.Interfaces;
using Platformer.Views;
using UnityEngine;

namespace Platformer.Controllers
{
    public class CoinsController : IUpdate, ICleanup
    {
        private const float _animationsSpeed = 10;

        private CharacterView _player;
        private SpriteAnimator _spriteAnimator;
        private List<LevelObjectView> _coinViews;

        public CoinsController(CharacterView player, List<LevelObjectView> coinViews, SpriteAnimator spriteAnimator)
        {
            _player = player;
            _spriteAnimator = spriteAnimator;
            _coinViews = coinViews;
            _player.OnLevelObjectContact += OnLevelObjectContact;

            foreach (var coinView in coinViews)
            {
                _spriteAnimator.StartAnimation(coinView.SpriteRenderer, AnimState.Idle, true, _animationsSpeed);
            }
        }

        private void OnLevelObjectContact(LevelObjectView contactView)
        {
            if (_coinViews.Contains(contactView))
            {
                _spriteAnimator.StopAnimation(contactView.SpriteRenderer);
                GameObject.Destroy(contactView.gameObject);
            }
        }
        
        public void Update(float deltaTime)
        {
            _spriteAnimator.Update(deltaTime);
        }

        public void Cleanup()
        {
            _player.OnLevelObjectContact -= OnLevelObjectContact;
        }
    }
}