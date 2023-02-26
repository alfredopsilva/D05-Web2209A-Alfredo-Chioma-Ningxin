using Chevalier.Utility.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevEmporium.Domain.Entities
{
    public class Cart : ViewModel
    {

        private const decimal QST = 0.0975m;
        private const decimal GST = 0.05m;

        // Properties
        public int Id { get; }
        public User User { get; }
        public decimal QstValue
        {
            get
            {
                return Subtotal * QST;
            }
        }

        public decimal GstValue
        {
            get
            {
                return Subtotal * GST;
            }
        }

        public decimal TotalValue
        {
            get
            {
                return Subtotal + QstValue + GstValue;
            }
        }
        public decimal Subtotal
        {
            get
            {
                decimal subtotal = 0;
                foreach (Product product in products)
                {
                    subtotal += product.Price;
                }

                return subtotal;
            }
        }

 

  
        private List<Product> products;

        public Cart(List<Product> products, User user)
        {
            this.products = products;
            this.User = user;
            
        }
    }
}
