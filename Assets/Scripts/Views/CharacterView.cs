using System;
using Platformer.Controllers;
using UnityEngine;

namespace Platformer.Views
{
    public class CharacterView : BaseView
    {
        [SerializeField]
        private SpriteRenderer _spriteRenderer;
        //[SerializeField]
        //private Transform _transform;
        [SerializeField]
        private Rigidbody2D _rigidbody2D;
        [SerializeField]
        private Collider2D _collider2D;

        //public Transform Transform => _transform;
        public Rigidbody2D Rigidbody2D => _rigidbody2D;
        public Collider2D Collider2D => _collider2D;
        public SpriteRenderer SpriteRenderer => _spriteRenderer;
        
        public Action<PlayerState> OnStateChange;
        public Action<LevelObjectView> OnLevelObjectContact { get; set; }

        private void OnTriggerEnter2D(Collider2D other)
        {
            var levelObject = other.gameObject.GetComponent<LevelObjectView>();
            
            if (levelObject != null)
                OnLevelObjectContact?.Invoke(levelObject);
        }
    }
}