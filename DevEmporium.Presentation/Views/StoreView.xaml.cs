using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;
using DevEmporium.Application.ViewModels;
using DevEmporium.Domain.Entities;

namespace DevEmporium.Presentation.Views
{
    /// <summary>
    /// Interaction logic for StoreView.xaml
    /// </summary>
    public partial class StoreView : Window
    {
        private StoreListViewModel storeViewListModel;
        public StoreView()
        {
            InitializeComponent();
            
            storeViewListModel = new StoreListViewModel();
            storeViewListModel.SelectedProductChanged += OnSelectedProductChanged;
            storeViewListModel.BuyProductActivated += OnBuyProductaActivated;
            
            DataContext = storeViewListModel;

            cartViewPanel.DataContext = new CartListViewModel(storeViewListModel.CartList, storeViewListModel.User, storeViewListModel.CartProducts, storeViewListModel.Cart);

        }

        private void OnBuyProductaActivated(Product product)
        {
            cartViewPanel.Visibility = Visibility.Visible;
            cartViewPanel.DataContext = new CartListViewModel(storeViewListModel.CartList, storeViewListModel.User, storeViewListModel.CartProducts, storeViewListModel.Cart);
        }

        private void OnBuyProductRequested()
        {
            // We should specific tell what the class is. Like CartWindow
         
        }

        private void OnSelectedProductChanged(Product product)
        {
            // TODO If else
            productViewPanel.Visibility = Visibility.Visible;
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
                DragMove();
        }

        private void btn_Minimize_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void btn_Close_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Application.Current.Shutdown();
        }
    }
}
