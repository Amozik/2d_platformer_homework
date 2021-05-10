using UnityEngine;

namespace Platformer.Views
{
    public class BulletView : BaseView
    {
        [SerializeField]
        private TrailRenderer _trail;
        [SerializeField]
        private Rigidbody2D _rigidbody2D;
        [SerializeField]
        private Collider2D _collider2D;
        
        public Rigidbody2D Rigidbody2D => _rigidbody2D;
        
        public void SetVisible(bool value)
        {
            if (_trail) _trail.enabled = value;
            if (_trail) _trail.Clear();
            gameObject.SetActive(value);
        }
    }
}