using System;
using Platformer.Data;
using Platformer.Extensions;
using Platformer.Interfaces;
using Platformer.Views;
using UnityEngine;

namespace Platformer.Controllers
{
    public enum PlayerState
    {
        Run,
        Idle,
        Jump,
    }

    public class PlayerTransformController : IUpdate
    {
        private const float G = -10f;    
        
        private readonly PlayerConfig _playerConfig;
        private readonly CharacterView _player;

        private float _yVelocity;
        private bool _doJump;
        private float _xAxisInput;
        private Vector3 _move = Vector3.zero;
        private Vector3 _look = Vector3.one;
        private PlayerState _currentState = PlayerState.Idle;

        public PlayerTransformController(PlayerConfig playerConfig, CharacterView player)
        {
            _player = player;
            _playerConfig = playerConfig;
        }
        
        private void GoSideWay(float deltaTime)
        {
            var speed = deltaTime * _playerConfig.walkSpeed;
            _move.Set(speed * _xAxisInput, 0, 0);
            _look.Set(Math.Sign(_xAxisInput), _look.y, _look.z);
            
            _player.Transform.position += _move;
            _player.Transform.localScale = _look; 
        }

        private bool IsGrounded()
        {
            return _player.Transform.position.y <= _playerConfig.groundLevel + float.Epsilon && _yVelocity<=0;
        }
        
        public void Update(float deltaTime)
        {
            _doJump = Input.GetAxis("Vertical") > 0;
            _xAxisInput = Input.GetAxis("Horizontal");
            var goSideWay = Mathf.Abs(_xAxisInput) > _playerConfig.movingThresh;

            var previousState = _currentState;
            
            if (IsGrounded())
            {
                //walking
                if (goSideWay) GoSideWay(deltaTime);
                _currentState = goSideWay ? PlayerState.Run : PlayerState.Idle;

                //start jump
                if (_doJump && _yVelocity == 0)
                {
                    _yVelocity = _playerConfig.jumpStartSpeed;
                }
                //stop jump
                else if(_yVelocity < 0)
                {
                    _yVelocity = 0;
                    _player.Transform.position = _player.Transform.position.Change(y: _playerConfig.groundLevel);
                }
            }
            else
            {
                //flying
                if (goSideWay) GoSideWay(deltaTime);
                if (Mathf.Abs(_yVelocity) > _playerConfig.flyThresh)
                {
                    _currentState = PlayerState.Jump;
                }
                _yVelocity += G * Time.deltaTime;
                _player.Transform.position += Vector3.up * (Time.deltaTime * _yVelocity);
            }

            if (_currentState != previousState) _player.OnStateChange?.Invoke(_currentState);
        }
    }
}