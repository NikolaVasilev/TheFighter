using System.Collections.Generic;

namespace Engine.Interfaces
{
    public interface IQuest
    {
        int ID { get; }
        string Name { get;}
        string Description { get;}
        int RewardExperiencePoints { get;}
        int RewardGold { get;}
        IItem RewardItem { get;}
        IList<QuestCompletionItem> QuestCompletionItems { get;}
    }
}