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
    /// Interaction logic for Administration.xaml
    /// </summary>
    public partial class Home : Window
    {
        public Home()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Administation frmAdmin = new Administation();
            this.Close();
            frmAdmin.Show();
            
        }

        private void AddRequirement_Click(object sender, RoutedEventArgs e)
        {
            AddRequirement frmAdmin = new AddRequirement();
            this.Close();
            frmAdmin.Show();

        }
    }
}
