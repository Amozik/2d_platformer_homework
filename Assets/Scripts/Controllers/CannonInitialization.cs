using Platformer.Views;
using UnityEngine;

namespace Platformer.Controllers
{
    public class CannonInitialization
    {
        public CannonView Cannon { get; }

        public CannonInitialization()
        {
            Cannon = Object.FindObjectOfType<CannonView>();
        }
    }
}