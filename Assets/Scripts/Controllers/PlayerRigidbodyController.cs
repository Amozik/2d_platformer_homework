using System;
using Platformer.Data;
using Platformer.Extensions;
using Platformer.Interfaces;
using Platformer.Physics;
using Platformer.Views;
using UnityEngine;

namespace Platformer.Controllers
{
    public class PlayerRigidbodyController : IFixedUpdate
    {
        private readonly PlayerConfig _playerConfig;
        private readonly CharacterView _player;
        private readonly ContactsPoller _contactsPoller;

        private bool _doJump;
        
        private float _xAxisInput;
        private PlayerState _currentState = PlayerState.Idle;

        public PlayerRigidbodyController(PlayerConfig playerConfig, CharacterView player)
        {
            _player = player;
            _playerConfig = playerConfig;
            _contactsPoller = new ContactsPoller(player.Collider2D);

        }

        public void FixedUpdate(float deltaTime)
        {
            _doJump = Input.GetAxis("Vertical") > 0;
            _xAxisInput = Input.GetAxis("Horizontal");
            _contactsPoller.FixedUpdate(deltaTime);
            var goSideWay = Mathf.Abs(_xAxisInput) > _playerConfig.movingThresh;

            var previousState = _currentState;
            
            if(goSideWay) _player.SpriteRenderer.flipX = _xAxisInput < 0;
            var newVelocity = 0f;
            
            if (goSideWay && 
                (_xAxisInput > 0 || !_contactsPoller.HasLeftContacts) && 
                (_xAxisInput < 0 || !_contactsPoller.HasRightContacts))
            {
                newVelocity = deltaTime * _playerConfig.walkSpeed * _xAxisInput;
            }
            _player.Rigidbody2D.velocity = _player.Rigidbody2D.velocity.Change(
                x: newVelocity);

            if (_contactsPoller.IsGrounded && _doJump && 
                Mathf.Abs(_player.Rigidbody2D.velocity.y) <= _playerConfig.jumpThresh)
            {
                _player.Rigidbody2D.AddForce(Vector3.up * _playerConfig.jumpForce);
            }

            if (_contactsPoller.IsGrounded)
            {
                _currentState = goSideWay ? PlayerState.Run : PlayerState.Idle;
            }
            else if (Mathf.Abs(_player.Rigidbody2D.velocity.y) > _playerConfig.flyThresh)
            {
                _currentState = PlayerState.Jump;
            }

            if (_currentState != previousState) _player.OnStateChange?.Invoke(_currentState);
        }
    }
}