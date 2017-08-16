namespace Engine.Interfaces
{
    public interface IItemFactory
    {
        IItem CreateItem(string type, object[] dataObjects);
    }
}