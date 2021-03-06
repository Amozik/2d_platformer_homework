using System;
using Pathfinding;

namespace Platformer.AI
{
    public class AIPatrolPath : AIPath
    {
        public new event EventHandler TargetReached;

        public override void OnTargetReached()
        {
            base.OnTargetReached();
            DispatchTargetReached();
        }

        protected virtual void DispatchTargetReached()
        {
            TargetReached?.Invoke(this, EventArgs.Empty);
        }
    }

}
