using System.Collections.Generic;
using Platformer.Interfaces;
using Platformer.Physics;
using Platformer.Views;
using UnityEngine;

namespace Platformer.Controllers
{
    public class BulletEmitterController : IUpdate
    {
        private const float _delay = 1;
        private const float _startSpeed = 5f;

        private List<PhysicsBullet> _bullets = new List<PhysicsBullet>();
        private Transform _transform;

        private int _currentIndex;
        private float _timeTillNextBullet;

        public BulletEmitterController(List<BulletView> bulletViews, Transform transform)
        {
            _transform = transform;
            foreach (var bulletView in bulletViews)
            {
                _bullets.Add(new PhysicsBullet(bulletView));
            }
        }

        public void Update(float deltaTime)
        {
            if(_timeTillNextBullet > 0)
            {
                _timeTillNextBullet -= deltaTime;
            }
            else
            {
                _timeTillNextBullet = _delay;
                _bullets[_currentIndex].Throw(_transform.position, _transform.up * _startSpeed);
                _currentIndex++;
                if (_currentIndex >= _bullets.Count) _currentIndex = 0;
            }
        }
    }
}