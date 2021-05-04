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
            var levelInitialization = new LevelInitialization();

            var player = playerInitialization.GetPlayer();
            var level = levelInitialization.Level;
            controllers.Add(levelInitialization.WaterAnimator); 
            
            controllers.Add(playerInitialization);

            controllers.Add(new PlayerAnimationController(data.playerConfig, player));
            controllers.Add(new PlayerRigidbodyController(data.playerConfig, player));
            controllers.Add(new CannonAimController(level.CanonView.MuzzleTransform, player.Transform));
            controllers.Add(new BulletEmitterController(level.CanonView.BulletViews, level.CanonView.EmmiterTransform));
            controllers.Add(new CoinsController(player, level.CoinViews, new SpriteAnimator(data.coinAnimationsConfig)));
            controllers.Add(new CameraController(player.Transform, camera.transform));
            controllers.Add(new LevelCompleteManager(player, level.DeathZones, level.WinZones));
            controllers.Add(new ParallaxManager(camera.transform, data.back));

            if (level.SimpleEnemy != null)
                level.SimpleEnemy.target = player.Transform;
        }
    }
}