using Platformer.Views;
using UnityEngine;

namespace Platformer.Data
{
    [CreateAssetMenu(fileName = nameof(PlayerConfig), menuName = "Configs/" + nameof(PlayerConfig), order = 0)]
    public class PlayerConfig : ScriptableObject
    {
        public CharacterView view;
        public SpriteAnimationsConfig spriteAnimationsConfig;
        public int animationSpeed = 10;
        public float walkSpeed = 3f;
        public float jumpStartSpeed = 8f;
        public float movingThresh = 0.1f;
        public float flyThresh = 1f;
        public float groundLevel = 0.5f;
    }
}