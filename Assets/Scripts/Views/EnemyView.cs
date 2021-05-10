using UnityEngine;

namespace Platformer.Views
{
    public class EnemyView : BaseView
    {
        [SerializeField]
        private SpriteRenderer _spriteRenderer;
        [SerializeField]
        private Rigidbody2D _rigidbody2D;
        [SerializeField]
        private Collider2D _collider2D;
        
        public Rigidbody2D Rigidbody2D => _rigidbody2D;
        public Collider2D Collider2D => _collider2D;
        public SpriteRenderer SpriteRenderer => _spriteRenderer;
    }
}