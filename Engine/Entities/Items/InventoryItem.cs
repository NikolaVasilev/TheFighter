using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Engine.Interfaces;

namespace Engine
{
    public class InventoryItem : INotifyPropertyChanged
    {
        private IItem _details;
        private int _quantity;
        public event PropertyChangedEventHandler PropertyChanged;
        public int ItemID
        {
            get { return Details.ID; }
        }

        public int Price
        {
            get { return Details.Price; }
        }
        public IItem Details
        {
            get { return _details; }
            set
            {
                _details = value;
                OnPropertyChanged("Details");
            }
        }

        public int Quantity
        {
            get { return _quantity; }
            set
            {
                _quantity = value;
                OnPropertyChanged("Quantity");
                OnPropertyChanged("Description");
            }
        }

        protected void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }

        public InventoryItem(IItem details, int quantity)
        {
            Details = details;
            Quantity = quantity;
        }

        public string Description
        {
            get { return Quantity > 1 ? Details.NamePlural : Details.Name; }
        }
    }
}
