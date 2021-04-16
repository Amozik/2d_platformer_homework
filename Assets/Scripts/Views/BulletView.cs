using UnityEngine;

namespace Platformer.Views
{
    public class BulletView : BaseView
    {
        [SerializeField]
        private TrailRenderer _trail;
        
        public void SetVisible(bool value)
        {
            if (_trail) _trail.enabled = value;
            if (_trail) _trail.Clear();
            gameObject.SetActive(value);
        }
    }
}