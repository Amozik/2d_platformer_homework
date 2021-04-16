using UnityEngine;

namespace Platformer.Views
{
    public class BaseView : MonoBehaviour
    {
        [SerializeField]
        private Transform _transform;

        public Transform Transform => _transform;
    }
}