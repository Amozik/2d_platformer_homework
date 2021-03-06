using UnityEngine;

namespace Platformer.Data
{
    [CreateAssetMenu(fileName = nameof(GameConfig),  menuName = "Configs/" + nameof(GameConfig), order = 0)]
    public class GameConfig : ScriptableObject
    {
        public PlayerConfig playerConfig;
        public SpriteAnimationsConfig coinAnimationsConfig;
        public GameObject back;
    }
}