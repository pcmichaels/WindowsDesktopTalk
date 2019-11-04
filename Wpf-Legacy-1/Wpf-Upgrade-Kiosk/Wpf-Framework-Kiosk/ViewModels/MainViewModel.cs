using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Wpf_Framework_Kiosk.Helpers;
using Wpf_Framework_Kiosk.Models;

namespace Wpf_Framework_Kiosk.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private string _barCode;
        private decimal _itemPrice;
        private int _quantity;
        private decimal _totalPrice;
        private string _description;

        private List<Product> Inventory { get; set; }

        public string BarCode
        {
            get => _barCode;
            set
            {
                UpdateProperty(ref _barCode, value);
                UpdateProduct();
            }
        }
        public decimal ItemPrice
        {
            get => _itemPrice;
            set => UpdateProperty(ref _itemPrice, value);
        }
        public int Quantity
        {
            get => _quantity;
            set
            {
                UpdateProperty(ref _quantity, value);
                UpdateQuantity();
            }
        }
        public decimal TotalPrice
        {
            get => _totalPrice;
            set => UpdateProperty(ref _totalPrice, value);
        }
        public string Description 
        { 
            get => _description;
            set => UpdateProperty(ref _description, value);
        }

        private void UpdateQuantity()
        {
            TotalPrice = ItemPrice * Quantity;
        }

        private void UpdateProduct()
        {
            string products = ReadData.Products();
            var productData = JsonConvert.DeserializeObject<Inventory>(products);
            var findProduct = productData.Product.FirstOrDefault(a => a.ProductCode == BarCode);
            if (findProduct == null) return;

            Description = findProduct.Description;
            ItemPrice = findProduct.UnitPrice;
        }

        protected void UpdateProperty<T>(ref T property, T value, [CallerMemberName] string name = null)
        {
            if (name == null) return;

            property = value;
            OnPropertyChanged(name);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string name) =>
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));

    }
}
