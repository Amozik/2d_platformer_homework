using System;
using Platformer.Controllers;
using UnityEngine;

namespace Platformer.Views
{
    public class CharacterView : MonoBehaviour
    {
        [SerializeField]
        private SpriteRenderer _spriteRenderer;
        [SerializeField]
        private Transform _transform;

        public Transform Transform => _transform;
        public SpriteRenderer SpriteRenderer => _spriteRenderer;
        
        public Action<PlayerState> OnStateChange;
        
    }
}