using System;
using System.Collections.Generic;
using System.Linq;
using Platformer.Quests.Interfaces;
using UnityEngine;

namespace Platformer.Quests
{
    public sealed class ResettableQuestStory : IQuestStory
    {
        private readonly List<IQuest> _questsCollection;
        private int _currentIndex;

        public ResettableQuestStory(List<IQuest> questsCollection)
        {
            _questsCollection = questsCollection ?? throw new ArgumentNullException(nameof(questsCollection));
            Subscribe();
            // все квесты активны сразу
            ResetQuests();
        }

        private void Subscribe()
        {
            foreach (var quest in _questsCollection)
            {
                quest.Completed += OnQuestCompleted;
            }
        }
  
        private void Unsubscribe()
        {
            foreach (var quest in _questsCollection)
            {
                quest.Completed -= OnQuestCompleted;
            }
        }
  
        private void OnQuestCompleted(object sender, IQuest quest)
        {
            var index = _questsCollection.IndexOf(quest);
            // отслеживаем текущий индекс
            if (_currentIndex == index)
            {
                _currentIndex++;
                if (IsDone) Debug.Log("Story done!");
            }
            else
            {
                // сбрасываем цепочку, если был выполнен не целевой квест
                ResetQuests();
            }
        }

        private void ResetQuests()
        {
            _currentIndex = 0;
            foreach (var quest in _questsCollection)
            {
                quest.Reset();
            }
        }
        public bool IsDone => _questsCollection.All(value => value.IsCompleted);
  
        public void Dispose()
        {
            Unsubscribe();
            foreach (var quest in _questsCollection)
            {
                quest.Dispose();
            }
        }
    }

}