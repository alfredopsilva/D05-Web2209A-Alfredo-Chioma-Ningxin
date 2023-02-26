using Chevalier.Utility.ViewModels;
using DevEmporium.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevEmporium.Application.ViewModels
{
    public class CartListViewModel : ViewModel, INotifyPropertyChanged
    {
        private Cart cart;
        private List<Product> cartProducts;
        public ObservableCollection<Product> cartCollection { get; }

        private User user;

        public CartListViewModel(List<Product> cartProducts, User user, ObservableCollection<Product> cartCollection, Cart cart)
        {
            this.cartProducts = cartProducts;
            this.user = user;
            this.cartCollection = cartCollection;
            this.cart = cart;
        }

        public string NumberOfProducts
        {
            get
            {
                if (cartProducts.Count == 1)
                {
                    return $"{cartProducts.Count} Unit";

                }
                return $"{cartProducts.Count} Unit(s)";
                
            }
        }
        public string Subtotal
        {
            get
            {
                return cart?.Subtotal.ToString("$ " + "0.00");
            }
        }
        public string QstValue
        {
            get
            {
                return cart?.QstValue.ToString("$ " + "0.00");
            }
        }
        public string GstValue
        {
            get
            {
                return cart?.GstValue.ToString("$ " + "0.00");
            }
        }
        public string TotalValue
        {
            get
            {
                return cart?.TotalValue.ToString("$ " + "0.00");
            }
        }
    }
}
