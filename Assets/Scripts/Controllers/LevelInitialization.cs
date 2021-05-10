using Platformer.Data;
using Platformer.Levels;
using UnityEngine;

namespace Platformer.Controllers
{
    public class LevelInitialization
    {
        public BaseLevel Level { get; }
        public SpriteAnimator WaterAnimator { get; }

        public LevelInitialization()
        {
            //TODO: Инициализировать из префаба, который будет указан в конфиге
            Level = Object.FindObjectOfType<BaseLevel>();

            if (Level.Water != null)
            {
                WaterAnimator = new SpriteAnimator(Level.WaterAnimationsConfig);
                WaterAnimator.StartAnimation(Level.Water, AnimState.Idle, true, 10);
            }
        }
    }
}