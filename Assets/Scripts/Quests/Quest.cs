using System;
using Platformer.Quests.Interfaces;
using Platformer.Views;

namespace Platformer.Quests
{
    public sealed class Quest : IQuest
    {
        private readonly QuestObjectView _view;
        private readonly IQuestModel _model;
 
        private bool _active;

        public Quest(QuestObjectView view, IQuestModel model)
        {
            _view = view != null ? view : throw new ArgumentNullException(nameof(view));
            _model = model != null ? model : throw new ArgumentNullException(nameof(model));
        }
        
        private void OnContact(BaseView arg2)
        {
            var completed = _model.TryComplete(arg2.gameObject);
            if (completed) Complete();
        }
  
        private void Complete()
        {
            if (!_active) return;
            _active = false;
            IsCompleted = true;
            _view.OnLevelObjectContact -= OnContact;
            _view.ProcessComplete();
            OnCompleted();
        }
  
        private void OnCompleted()
        {
            Completed?.Invoke(this, this);
        }

        public event EventHandler<IQuest> Completed;
        public bool IsCompleted { get; private set; }
  
        public void Reset()
        {
            if (_active) return;
            _active = true;
            IsCompleted = false;
            _view.OnLevelObjectContact += OnContact;
            _view.ProcessActivate();
        }

        public void Dispose()
        {
            _view.OnLevelObjectContact -= OnContact;
        }
    }
}