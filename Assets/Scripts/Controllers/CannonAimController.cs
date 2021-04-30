using Platformer.Interfaces;
using UnityEngine;

namespace Platformer.Controllers
{
    public class CannonAimController : IUpdate
    {
        private Transform _muzzleTransform;
        private Transform _aimTransform;

        public CannonAimController(Transform muzzleTransform, Transform aimTransform)
        {
            _muzzleTransform = muzzleTransform;
            _aimTransform = aimTransform;
        }

        public void Update(float deltaTime)
        {
            var dir = _aimTransform.position - _muzzleTransform.position;
            var angle = Vector3.Angle(Vector3.down, dir);
            var axis = Vector3.Cross(Vector3.down, dir);
            _muzzleTransform.rotation = Quaternion.AngleAxis(angle, axis);
        }

    }
}