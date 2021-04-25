using Platformer.Levels;
using UnityEngine;

namespace Platformer.Controllers
{
    public class LevelInitialization
    {
        public BaseLevel Level { get; }

        public LevelInitialization()
        {
            //TODO: Инициализировать из префаба, который будет указан в конфиге
            Level = Object.FindObjectOfType<BaseLevel>();
        }
    }
}