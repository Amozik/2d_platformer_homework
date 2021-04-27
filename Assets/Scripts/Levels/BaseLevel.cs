using System.Collections.Generic;
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

        public List<LevelObjectView> CoinViews => _coinViews;
        public List<LevelObjectView> DeathZones => _deathZones;
        public List<LevelObjectView> WinZones => _winZones;
        public CannonView CanonView => _canonView;
    }
}