using System.Collections.Generic;
using Pathfinding;
using Platformer.Data;
using Platformer.Views;
using UnityEngine;

namespace Platformer.Levels
{
    public class BaseLevel : MonoBehaviour
    {
        [SerializeField]
        private List<LevelObjectView> _coinViews;
        
        [SerializeField]
        private List<LevelObjectView> _deathZones;
        [SerializeField]
        private List<LevelObjectView> _winZones;
        [SerializeField]
        private CannonView _canonView;
        [SerializeField]
        private SpriteRenderer _water;
        [SerializeField]
        private SpriteAnimationsConfig _waterAnimationsConfig;

        [SerializeField]
        private AIDestinationSetter _simpleEnemy;

        [SerializeField] 
        private GenerateLevelView _generateLevelView;
        
        public List<LevelObjectView> CoinViews => _coinViews;
        public List<LevelObjectView> DeathZones => _deathZones;
        public List<LevelObjectView> WinZones => _winZones;
        public CannonView CanonView => _canonView;
        public SpriteRenderer Water => _water;
        public SpriteAnimationsConfig WaterAnimationsConfig => _waterAnimationsConfig;
        public AIDestinationSetter SimpleEnemy => _simpleEnemy;
        public GenerateLevelView GenerateLevelView => _generateLevelView;
    }
}