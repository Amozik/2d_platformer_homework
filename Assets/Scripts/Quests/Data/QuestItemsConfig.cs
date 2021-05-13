using System.Collections.Generic;
using UnityEngine;

namespace Platformer.Quests.Data
{
    [CreateAssetMenu(fileName = nameof(QuestItemsConfig), menuName = "Configs/" + nameof(QuestItemsConfig), order = 0)]
    public class QuestItemsConfig : ScriptableObject
    {
        public int questId;
        public List<int> questItemIdCollection;
    }
}