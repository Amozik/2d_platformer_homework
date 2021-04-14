using System;
using System.Collections.Generic;
using UnityEngine;

namespace Platformer.Data
{
    public enum AnimState
    {
        Idle,
        Run,
        Jump,
    }
    
    [CreateAssetMenu(fileName = nameof(SpriteAnimationsConfig), menuName = "Configs/" + nameof(SpriteAnimationsConfig), order = 1)]
    public class SpriteAnimationsConfig : ScriptableObject
    {
        [Serializable]
        public class SpritesSequence
        {
            public AnimState Track;
            public List<Sprite> Sprites = new List<Sprite>();
        }
        
        public List<SpritesSequence> Sequences = new List<SpritesSequence>();
    }
}