using System.Collections.Generic;
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

        public List<LevelObjectView> CoinViews => _coinViews;
        public List<LevelObjectView> DeathZones => _deathZones;
        public List<LevelObjectView> WinZones => _winZones;
        public CannonView CanonView => _canonView;
        public SpriteRenderer Water => _water;
        public SpriteAnimationsConfig WaterAnimationsConfig => _waterAnimationsConfig;
    }
}