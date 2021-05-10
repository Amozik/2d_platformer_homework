using UnityEngine;

namespace Platformer.Quests.Data
{
    [CreateAssetMenu(fileName = nameof(QuestStoryConfig), menuName = "Configs/" + nameof(QuestStoryConfig), order = 0)]
    public class QuestStoryConfig : ScriptableObject
    {
        public QuestConfig[] quests;
        public QuestStoryType questStoryType;
    }
    public enum QuestStoryType
    {
        Common,
        Resettable
    }
}