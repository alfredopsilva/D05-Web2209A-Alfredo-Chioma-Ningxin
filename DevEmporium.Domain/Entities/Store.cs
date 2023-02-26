using Chevalier.Utility.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevEmporium.Domain.Entities
{
    public class Store : ViewModel
    {
        public string StoreName { get; private set; }
        public string StoreSlogan { get; private set; }
        private List<Product> _products;

        public Store(string storeName, string storeSlogan)
        {
            StoreName = storeName;
            StoreSlogan = storeSlogan;
            _products = new List<Product>();
        }
    }
}
