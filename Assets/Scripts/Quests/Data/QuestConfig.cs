using UnityEngine;

namespace Platformer.Quests.Data
{
    [CreateAssetMenu(fileName = nameof(QuestConfig), menuName = "Configs/" + nameof(QuestConfig), order = 0)]
    public class QuestConfig : ScriptableObject
    {
        public int id;
        public QuestType questType;
    }

    public enum QuestType
    {
        Switch,
    }
}