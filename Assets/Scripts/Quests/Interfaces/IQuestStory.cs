using System;

namespace Platformer.Quests.Interfaces
{
    public interface IQuestStory : IDisposable
    {
        bool IsDone { get; }
    }
}