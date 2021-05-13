using UnityEngine;

namespace Platformer.Quests.Interfaces
{
    public interface IQuestModel
    {
        bool TryComplete(GameObject activator);
    }
}