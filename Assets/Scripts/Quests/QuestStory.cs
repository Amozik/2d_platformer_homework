using System;
using System.Collections.Generic;
using System.Linq;
using Platformer.Quests.Interfaces;
using UnityEngine;

namespace Platformer.Quests
{
    public sealed class QuestStory : IQuestStory
    {
        private readonly List<IQuest> _questsCollection;
        private readonly QuestObjectView _questStoryCompleteView;
  
        public QuestStory(List<IQuest> questsCollection, QuestObjectView questStoryCompleteView)
        {
            // квесты загружаются в цепочку извне
            _questsCollection = questsCollection ?? throw new ArgumentNullException(nameof(questsCollection));
            _questStoryCompleteView = questStoryCompleteView;
            Subscribe();
            // старт первого квеста
            ResetQuest(0);
        }
        
        private void Subscribe()
        {
            foreach (var quest in _questsCollection) quest.Completed += OnQuestCompleted;
        }
  
        private void Unsubscribe()
        {
            foreach (var quest in _questsCollection) quest.Completed -= OnQuestCompleted;
        }

        private void OnQuestCompleted(object sender, IQuest quest)
        {
            var index = _questsCollection.IndexOf(quest);
            if (IsDone)
            {
                _questStoryCompleteView?.ProcessComplete();
                Debug.Log("Story done!");
            }
            else
            {
                // если очередной квест выполнен, запускаем следующий квест
                ResetQuest(++index);
            }
        }

        private void ResetQuest(int index)
        {
            if (index < 0 || index >= _questsCollection.Count) return;
            var nextQuest = _questsCollection[index];
            if (nextQuest.IsCompleted) OnQuestCompleted(this, nextQuest);
            else _questsCollection[index].Reset();
        }
        
        public bool IsDone => _questsCollection.All(value => value.IsCompleted);
  
        public void Dispose()
        {
            Unsubscribe();
            foreach (var quest in _questsCollection) quest.Dispose();
        }
    }
}