using System.Collections.Generic;
using Platformer.Interfaces;
using Platformer.Views;
using UnityEngine;

namespace Platformer.Controllers
{
    public class LevelCompleteManager : ICleanup
    {
        private Vector3 _startPosition;
        private CharacterView _player;
        private List<LevelObjectView> _deathZones;
        private List<LevelObjectView> _winZones;

        public LevelCompleteManager(CharacterView player, List<LevelObjectView> deathZones, List<LevelObjectView> winZones)
        {
            _startPosition = player.Transform.position;
            player.OnLevelObjectContact += OnLevelObjectContact;

            _player = player;
            _deathZones = deathZones;
            _winZones = winZones;
        }

        private void OnLevelObjectContact(LevelObjectView contactView)
        {
            if (_deathZones.Contains(contactView))
            {
                _player.Transform.position = _startPosition;
            }
        }

        public void Cleanup()
        {
            _player.OnLevelObjectContact -= OnLevelObjectContact;
        }
        
    }
}