using System;
using System.Collections;
using System.Collections.Generic;
using Platformer.Controllers;
using Platformer.Data;
using UnityEngine;

namespace Platformer
{
    public class GameController : MonoBehaviour, IDisposable
    {
        [SerializeField] 
        private GameConfig _gameConfig;
        
        private CompositeControllers _controllersHandler;

        private void Awake()
        {
            _controllersHandler = new CompositeControllers();
            
            var gameInitialization = new GameInitialization(_controllersHandler, _gameConfig);
        }

        private void Start()
        {
            _controllersHandler.Initialization();
        }

        private void Update()
        {
            var deltaTime = Time.deltaTime;
            _controllersHandler.Update(deltaTime);
        }

        private void FixedUpdate()
        {
            var deltaTime = Time.fixedDeltaTime;
            _controllersHandler.FixedUpdate(deltaTime);
        }


        public void Dispose()
        {
            _controllersHandler.Cleanup();
        }
    }
}


