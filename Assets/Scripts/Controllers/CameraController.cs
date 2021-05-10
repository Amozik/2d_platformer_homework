using Platformer.Interfaces;
using UnityEngine;

namespace Platformer.Controllers
{
    public class CameraController : IUpdate
    {
        private Transform _player;
        private Transform _mainCamera;
        
        private Vector3 _offset;

        public CameraController(Transform player, Transform mainCamera)
        {
            _player = player;
            _mainCamera = mainCamera;
            _offset = _mainCamera.localPosition - _player.position;
            _offset.z = _mainCamera.localPosition.z;
        }

        public void Update(float deltaTime)
        {
            _mainCamera.localPosition = _player.position + _offset;
        }
    }
}