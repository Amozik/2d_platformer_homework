using System;
using Platformer.Views;
using UnityEngine;

namespace Platformer.AI
{
    public class SimplePatrolAI
    {
        private readonly EnemyView _view;
        private readonly SimplePatrolModel _model;

        public SimplePatrolAI(EnemyView view, SimplePatrolModel model)
        {
            _view = view != null ? view : throw new ArgumentNullException(nameof(view));
            _model = model != null ? model : throw new ArgumentNullException(nameof(model));
        }

        public void FixedUpdate()
        {
            var newVelocity = _model.CalculateVelocity(_view.Transform.position) * Time.fixedDeltaTime;
            _view.Rigidbody2D.velocity = newVelocity;
        }
    }
}
