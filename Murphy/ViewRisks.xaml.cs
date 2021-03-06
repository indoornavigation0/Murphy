﻿using Murphy.DataAccess;
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

namespace Murphy
{
    /// <summary>
    /// Interaction logic for ViewRisks.xaml
    /// </summary>
    public partial class ViewRisks : Window
    {
        public ViewRisks()
        {
            InitializeComponent();
            DatabaseMethods _data = new DatabaseMethods();
            var items = _data.GetAllRisks();
            tblRisks.ItemsSource = items;
        }
        private void Back_Click(object sender, RoutedEventArgs e)
        {
            Administation frmHome = new Administation();
            frmHome.Show();
            this.Close();
        }
    }
}
