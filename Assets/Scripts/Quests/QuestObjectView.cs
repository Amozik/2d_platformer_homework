using Platformer.Views;
using UnityEngine;

namespace Platformer.Quests
{
    public abstract class QuestObjectView : LevelObjectView
    {
        [SerializeField]
        private int _id;
        
        public int Id => _id;
        
        public abstract void ProcessComplete();
        public abstract void ProcessActivate();

    }
}