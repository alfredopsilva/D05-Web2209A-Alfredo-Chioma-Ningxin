using Chevalier.Utility.Commands;
using Chevalier.Utility.ViewModels;
using DevEmporium.Domain.Entities;
using DevEmporium.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevEmporium.Application.ViewModels
{
    public delegate void ProductEventHandler(Product product);

    public class StoreListViewModel : ViewModel, INotifyPropertyChanged
    {
        public event ProductEventHandler SelectedProductChanged;
        public event ProductEventHandler BuyProductActivated;

        // Properties 
        public ObservableCollection<Product> Products { get; }
        public ObservableCollection<Product> CartProducts { get; }
        public List<Product> CartList { get; set; }
        public Product SelectedProduct
        {
            get
            {
                return _selectedProduct;
            }
            set
            {
                _selectedProduct = value;
                SelectedProductChanged?.Invoke(value);
                NotifyPropertyChanged(nameof(SelectedProduct));
            }
        }
        public DelegateCommand BuyCommand { get; }
        public User User { get; set; }

        public Cart Cart;

        //Fields
        private Product _selectedProduct;
        private ProductRepository repository;

        // Constructor 
        public StoreListViewModel()
        {
            repository = new ProductRepository();
            List<Product> productsList = repository.GetProducts();
            Products = new ObservableCollection<Product>(productsList);

            CartList = new List<Product>();
            Cart = new Cart(CartList, User);
            BuyCommand = new DelegateCommand(Buy);

            CartProducts = new ObservableCollection<Product>(CartList);

        }

        private void Buy(object _)
        {
            if (SelectedProduct != null)
            {
                CartList.Add(SelectedProduct);
                CartProducts.Add(SelectedProduct);
                BuyProductActivated?.Invoke(SelectedProduct);
            }

        }
    }
}
