using Platformer.Views;
using UnityEngine;

namespace Platformer.Quests
{
    public class ChangeColorQuestView : QuestObjectView
    {
        [SerializeField]
        private Color _completedColor;

        private Color _defaultColor;

        private void Awake()
        {
            _defaultColor = SpriteRenderer.color;
        }

        public override void ProcessComplete()
        {
            SpriteRenderer.color = _completedColor;
        }
  
        public override void ProcessActivate()
        {
            SpriteRenderer.color = _defaultColor;
        }
    }
}