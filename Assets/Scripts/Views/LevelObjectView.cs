using System;
using UnityEngine;

namespace Platformer.Views
{
    public class LevelObjectView : BaseView
    {
        [SerializeField]
        private SpriteRenderer _spriteRenderer;
        // [SerializeField]
        // private Collider2D _collider2D;
        
        public SpriteRenderer SpriteRenderer => _spriteRenderer;
        
        public Action<BaseView> OnLevelObjectContact { get; set; }
        
        //TODO: временное решение, эта логика есть в character view
        private void OnTriggerEnter2D(Collider2D other)
        {
            var levelObject = other.gameObject.GetComponent<BaseView>();
            
            if (levelObject != null)
                OnLevelObjectContact?.Invoke(levelObject);
        }
    }
}