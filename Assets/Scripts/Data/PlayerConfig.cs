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
    }
}