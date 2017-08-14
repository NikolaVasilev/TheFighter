namespace Engine.Interfaces
{
    public interface ILivingCreature
    {
        int CurrentHitPoints { get; } 
        int MaximumHitPoints { get; }
    }
}