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
    /// Interaction logic for Administation.xaml
    /// </summary>
    public partial class Administation : Window
    {
        public Administation()
        {
            InitializeComponent();
        }       

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            Home frmHome = new Home();
            frmHome.Show();
            this.Close();
        }

        private void addAgent_Click(object sender, RoutedEventArgs e)
        {
            AddAgent frmAgent = new AddAgent();
            frmAgent.Show();
            this.Close();
        }

        private void viewAgents_Click(object sender, RoutedEventArgs e)
        {
            ViewAgents frmAgent = new ViewAgents();
            frmAgent.Show();
            this.Close();
        }

        private void addAction_Click(object sender, RoutedEventArgs e)
        {
            AddAction frmAgent = new AddAction();
            frmAgent.Show();
            this.Close();
        }

        private void viewActions_Click(object sender, RoutedEventArgs e)
        {
            ViewActions frmAgent = new ViewActions();
            frmAgent.Show();
            this.Close();
        }

        private void addRisk_Click(object sender, RoutedEventArgs e)
        {
            AddRisk frmAgent = new AddRisk();
            frmAgent.Show();
            this.Close();
        }

        private void viewRisks_Click(object sender, RoutedEventArgs e)
        {
            ViewRisks frmAgent = new ViewRisks();
            frmAgent.Show();
            this.Close();
        }



    }
}
