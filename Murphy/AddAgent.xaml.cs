using Murphy.DataAccess;
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
    /// Interaction logic for AddAgent.xaml
    /// </summary>
    public partial class AddAgent : Window
    {
       
        public AddAgent()
        {
           
            InitializeComponent();
        }
        private void Back_Click(object sender, RoutedEventArgs e)
        {
            Administation frmHome = new Administation();
            frmHome.Show();
            this.Close();
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            try
            {
               DatabaseMethods _data = new DatabaseMethods();
               int i = _data.AddAgent(txtAgent.Text);
               if(i>0)
                {
                    MessageBox.Show("Successfully Added");
                    ViewAgents viewAgents = new ViewAgents();
                    viewAgents.Show();
                    this.Close();
                }
               else
                {
                    MessageBox.Show("Error Occured while saving Agent. Please try again");
                }
               
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Occured while saving Agent. Please try again");                
            }
            

        }
    }
}
