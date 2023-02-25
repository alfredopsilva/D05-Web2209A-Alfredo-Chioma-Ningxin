using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;


namespace ShoppingCart
{
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        private List<Product> productList;
        private double totalPrice;

        public event PropertyChangedEventHandler PropertyChanged;

        public MainWindow()
        {
            InitializeComponent();

            productList = new List<Product>
            {
                new Product { ProductId = 1, ProductName = "COAT", Quantity = 0, Price = 10.00 },
                new Product { ProductId = 2, ProductName = "JEAN", Quantity = 0, Price = 20.00 },
                new Product { ProductId = 3, ProductName = "PANT", Quantity = 0, Price = 30.00 },
                new Product { ProductId = 4, ProductName = "SHIRT", Quantity = 0, Price = 40.00 },
                new Product { ProductId = 5, ProductName = "SHORT", Quantity = 0, Price = 50.00 },
                new Product { ProductId = 6, ProductName = "SUIT", Quantity = 0, Price = 50.00 },
                new Product { ProductId = 7, ProductName = "SWEATER", Quantity = 0, Price = 50.00 },
                new Product { ProductId = 8, ProductName = "LOUNGEWEAR", Quantity = 0, Price = 50.00 },
                new Product { ProductId = 9, ProductName = "BOOT", Quantity = 0, Price = 50.00 },
                new Product { ProductId = 10, ProductName = "SNEAKER", Quantity = 0, Price = 50.00 },
            };

            
            productIdListView.ItemsSource = productList;
            productNameListView.ItemsSource = productList;
            quantityListView.ItemsSource = productList;
            priceListView.ItemsSource = productList;

            UpdateTotalPrice();
            PropertyChanged += (s, e) =>
            {
                if (e.PropertyName == "totalPrice")
                {
                    UpdateTotalPrice();
                }
            };
        }

        private void UpdateTotalPrice()
        {
            totalPrice = 0;
            foreach (var product in productList)
            {
                totalPrice += product.Price * product.Quantity;
            }
            totalPriceLabel.Content = totalPrice.ToString("C");
        }

        private void IncreaseButton_Click(object sender, RoutedEventArgs e)
        {
            var button = (Button)sender;
            var product = (Product)button.DataContext;
            product.Quantity++;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("totalPrice"));
        }

        private void DecreaseButton_Click(object sender, RoutedEventArgs e)
        {
            var button = (Button)sender;
            var product = (Product)button.DataContext;
            if (product.Quantity > 0)
            {
                product.Quantity--;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("totalPrice"));
            }
        }

        private void CheckoutButton_Click(object sender, RoutedEventArgs e)
        {
            
            MessageBox.Show($"Total price: {totalPrice.ToString("C")}");
        }
    }

    public class Product
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
    }
}
