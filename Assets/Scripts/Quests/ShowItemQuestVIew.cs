namespace Platformer.Quests
{
    public class ShowItemQuestVIew : QuestObjectView
    {
        public void Awake()
        {
            gameObject.SetActive(false);
        }

        public override void ProcessComplete()
        {
            gameObject.SetActive(true);
        }

        public override void ProcessActivate()
        {
            gameObject.SetActive(false);
        }
    }
}