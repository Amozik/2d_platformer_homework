using System;
using Platformer.Extensions;
using Platformer.Interfaces;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Platformer.Controllers
{
    //TODO: разделить back на отдельные части с выносом настроек для каждой в виде списка
    public class ParallaxManager : IUpdate
    {
        private Transform _camera;
        private Transform _back;
        private Vector3 _backStartPosition;
        private Vector3 _cameraStartPosition;
        private Vector2 _multiplier = new Vector2(0.4f, .2f);
        private float offset = 61.4f;

        public ParallaxManager(Transform camera, GameObject back)
        {
            _camera = camera;
            _back = Object.Instantiate(back).transform;
            _backStartPosition = _back.transform.position;
            _cameraStartPosition = _camera.transform.position;

            var doubleBack = Object.Instantiate(back, _back).transform;
            doubleBack.position = doubleBack.position.Change(x: offset);
        }

        public void Update(float deltaTime)
        {
            var cameraPosition = _camera.position;
            var backPosition = _back.position;
            var deltaCameraPosition = cameraPosition - _cameraStartPosition;
            
            backPosition += (Vector3)(deltaCameraPosition * _multiplier);
            _cameraStartPosition = cameraPosition;

            var offsetPositionX = Mathf.Repeat(cameraPosition.x - backPosition.x, offset);
            backPosition = backPosition.Change(cameraPosition.x - offsetPositionX);
            _back.position = backPosition;
        }
    }
}