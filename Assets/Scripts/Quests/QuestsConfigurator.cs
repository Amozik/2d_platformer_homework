using System;
using System.Collections.Generic;
using System.Linq;
using Platformer.Quests.Data;
using Platformer.Quests.Interfaces;
using UnityEngine;

namespace Platformer.Quests
{
    public class QuestsConfigurator : MonoBehaviour
    {
        [SerializeField]
        private QuestStoryConfig[] _questStoryConfigs;
        [SerializeField]
        private QuestObjectView[] _questObjects;
        [SerializeField]
        private QuestObjectView[] _completeQuestStoryObjects;

        private readonly Dictionary<QuestType, Func<IQuestModel>> _questFactories = new Dictionary<QuestType, Func<IQuestModel>>
        {
            { QuestType.Switch, () => new SwitchQuestModel() },
        };
  
        private readonly Dictionary<QuestStoryType, Func<List<IQuest>, QuestObjectView, IQuestStory>> _questStoryFactories = new Dictionary<QuestStoryType, Func<List<IQuest>, QuestObjectView, IQuestStory>>
        {
            { QuestStoryType.Common, (questCollection, completeView) => new QuestStory(questCollection, completeView) },
            { QuestStoryType.Resettable, (questCollection, completeView) => new ResettableQuestStory(questCollection, completeView) },
        };

        private List<IQuestStory> _questStories;

        private void Start()
        {
            _questStories = new List<IQuestStory>();
            foreach (var questStoryConfig in _questStoryConfigs)
            {
                _questStories.Add(CreateQuestStory(questStoryConfig));
            }
        }

        private void OnDestroy()
        {
            foreach (var questStory in _questStories)
            {
                questStory.Dispose();
            }
            _questStories.Clear();
        }

        private IQuestStory CreateQuestStory(QuestStoryConfig config)
        {
            var quests = new List<IQuest>();
            foreach (var questConfig in config.quests)
            {
                // создаём квест на основе данных из ScriptableObject
                var quest = CreateQuest(questConfig);
                if (quest == null) continue;
                quests.Add(quest);
            }

            var completeQuestStoryView = _completeQuestStoryObjects.FirstOrDefault(value => value.Id == config.id);
            // какая логика будет у цепочки определяем по типу QuestStoryType
            return _questStoryFactories[config.questStoryType].Invoke(quests, completeQuestStoryView);
        }

        private IQuest CreateQuest(QuestConfig config)
        {
            var questId = config.id;
            var questView = _questObjects.FirstOrDefault(value => value.Id == config.id);
            if (questView == null)
            {
                // пытаемся найти представление для квеста
                Debug.LogWarning($"QuestsConfigurator :: Start : Can't find view of quest {questId.ToString()}");  
                return null;
            }

            if (_questFactories.TryGetValue(config.questType, out var factory))
            {
                // пытаемся создать модель для квеста по типу QuestType
                var questModel = factory.Invoke();
                return new Quest(questView, questModel);
            }

            Debug.LogWarning($"QuestsConfigurator :: Start : Can't create model for quest {questId.ToString()}");  
            return null;
        }
    }
}