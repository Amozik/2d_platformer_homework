using System;

namespace Platformer.Quests.Interfaces
{
    public interface IQuest : IDisposable
    {
        event EventHandler<IQuest> Completed;
        bool IsCompleted { get; }
        void Reset();
    }
}