using Chevalier.Utility.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevEmporium.Domain.Entities
{
    public class Product : ViewModel
    {
        //Properties
        public int Id { get; }
        public decimal Price { get; private set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public string Description { get; set; }
        public string Url { get; set; }


        public Product(int id, decimal price, string name, string url, string description, string category)
        {
            Price = price;
            Id = id;
            Name = name;
            Category = category;
            Description = description;
            Url = url;

        }

        public override string ToString()
        {
            return $"The product {Name}\n" +
                   $"Cost {Price}\n" +
                   $"And belong to {Category}\n";
        }
    }
}
