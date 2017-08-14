namespace Engine.Interfaces
{
    public interface IMonster
    {
        int ID { get; }
        string Name { get; }
        int MaximumDamage { get; }
        int RewardExperiencePoints { get; }
        int RewardGold { get; }
    }
}