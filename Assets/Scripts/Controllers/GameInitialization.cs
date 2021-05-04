using Platformer.Data;
using UnityEngine;

namespace Platformer.Controllers
{
    internal sealed class GameInitialization
    {
        public GameInitialization(CompositeControllers controllers, GameConfig data)
        {
            Camera camera = Camera.main;
            
            var playerInitialization = new PlayerInitialization(data.playerConfig.view);
            var cannonInitialization = new CannonInitialization();

            var player = playerInitialization.GetPlayer();
            
            controllers.Add(playerInitialization);

            controllers.Add(new PlayerAnimationController(data.playerConfig, player));
            controllers.Add(new PlayerTransformController(data.playerConfig, player));
            controllers.Add(new CannonAimController(cannonInitialization.Cannon.MuzzleTransform, player.Transform));
            controllers.Add(new BulletEmitterController(cannonInitialization.Cannon.BulletViews, cannonInitialization.Cannon.EmmiterTransform));
            controllers.Add(new ParallaxManager(camera.transform, data.back));
        }
    }
}