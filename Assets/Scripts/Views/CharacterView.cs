﻿using UnityEngine;

namespace Platformer.Views
{
    public class CharacterView : MonoBehaviour
    {
        [SerializeField]
        private SpriteRenderer _spriteRenderer;
        [SerializeField]
        private Transform _transform;

        public SpriteRenderer SpriteRenderer => _spriteRenderer;
    }
}