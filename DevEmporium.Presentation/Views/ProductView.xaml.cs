﻿using System;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DevEmporium.Presentation.Views
{
    /// <summary>
    /// Interaction logic for ProductView.xaml
    /// </summary>
    /// 

    public delegate void BuyProductHandler();
    public partial class ProductView : UserControl
    {
        public event BuyProductHandler BuyProductRequested;
        public ProductView()
        {
            InitializeComponent();
        }
    }
}
