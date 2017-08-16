using System;
using Engine.Interfaces;

namespace Engine.Factories
{
    public class ItemFactory : IItemFactory
    {
        private const string NamespaceName = "Engine";

        public IItem CreateItem(string type, object[] dataObjects)
        {
            Type getType = Type.GetType($"{NamespaceName}.{type}");

            return (IItem)Activator.CreateInstance(getType, dataObjects);
        }
    }
}