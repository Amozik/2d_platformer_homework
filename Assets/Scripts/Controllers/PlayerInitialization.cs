using Platformer.Interfaces;
using Platformer.Views;
using UnityEngine;

namespace Platformer.Controllers
{
    internal sealed class PlayerInitialization : IInitialization
    {
        private readonly CharacterView _player;

        public PlayerInitialization(CharacterView view)
        {
            _player = Object.Instantiate(view);
        }
        
        public CharacterView GetPlayer()
        {
            return _player;
        }

        public void Initialization()
        {

        }
    }
}