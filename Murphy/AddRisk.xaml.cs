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
    /// Interaction logic for AddRisk.xaml
    /// </summary>
    public partial class AddRisk : Window
    {
        public AddRisk()
        {
            InitializeComponent();
            DatabaseMethods _data = new DatabaseMethods();
            var items = _data.GetAllActionsDropdown();

            ddlAction.ItemsSource = items;
            //lbTodoList.Items.Add(new ComboBoxItem { Content = "A1" });
            ddlAction.DisplayMemberPath = "Name";
            ddlAction.SelectedValuePath = "Id";
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
                var risk = txtRisk.Text;
                var actionId = ddlAction.SelectedValue;
                int i = _data.AddRisk(risk, Convert.ToInt32(actionId));
                if (i > 0)
                {
                    MessageBox.Show("Successfully Added");
                    ViewRisks viewRisks = new ViewRisks();
                    viewRisks.Show();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Error Occured while saving Risk. Please try again");
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Occured while saving Risk. Please try again");
            }


        }
    }
}
