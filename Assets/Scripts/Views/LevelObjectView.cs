using UnityEngine;

namespace Platformer.Views
{
    public class LevelObjectView : BaseView
    {
        [SerializeField]
        private SpriteRenderer _spriteRenderer;
        
        public SpriteRenderer SpriteRenderer => _spriteRenderer;
    }
}