using Platformer.Interfaces;
using UnityEngine;

namespace Platformer.Controllers
{
    public class ParallaxManager : IUpdate
    {
        private Transform _camera;
        private Transform _back;
        private Vector3 _backStartPosition;
        private Vector3 _cameraStartPosition;
        private const float _coef = 0.3f;

        public ParallaxManager(Transform camera, GameObject back)
        {
            _camera = camera;
            _back = Object.Instantiate(back).transform;
            _backStartPosition = _back.transform.position;
            _cameraStartPosition = _camera.transform.position;
        }

        public void Update(float deltaTime)
        {
            _back.position = _backStartPosition + (_camera.position - _cameraStartPosition) * _coef;
        }
    }
}