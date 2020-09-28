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
    /// Interaction logic for AddAction.xaml
    /// </summary>
    public partial class AddAction : Window
    {
        public AddAction()
        {
            InitializeComponent();
            DatabaseMethods _data = new DatabaseMethods();
            var items = _data.GetAllAgents();

            ddlAction.ItemsSource = items;
            //lbTodoList.Items.Add(new ComboBoxItem { Content = "A1" });
            ddlAction.DisplayMemberPath = "Name";
            ddlAction.SelectedValuePath = "Id";
            
            
            
        }

        private void AddAction_Load(object sender, EventArgs e)
        {
           
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
                var action = txtAction.Text;
                var agentId = ddlAction.SelectedValue;
                var actionMech = txtActionMechanism.Text;
                var actionResp = txtActionResponse.Text;
                int i = _data.AddAction(action, Convert.ToInt32(agentId), actionMech, actionResp);
                if (i > 0)
                {
                    MessageBox.Show("Successfully Added");
                    ViewActions viewActions = new ViewActions();
                    viewActions.Show();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Error Occured while saving Action. Please try again");
                }
             

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Occured while saving Action. Please try again");
            }


        }
    }
}
