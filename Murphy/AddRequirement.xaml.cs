using Murphy.DataAccess;
using Murphy.Models;
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
    /// Interaction logic for AddRequirement.xaml
    /// </summary>
    public partial class AddRequirement : Window
    {
        public AddRequirement()
        {
            InitializeComponent();
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            Home frmAdmin = new Home();
            this.Close();
            frmAdmin.Show();

        }

        private void btnProcess_Click(object sender, RoutedEventArgs e)
        {
            string requirement = txtRequirement.Text;
            string specification = string.Empty;
            List<ReplaceParams> replaces = new List<ReplaceParams>();
            List<Specifications> specs = new List<Specifications>();
            DatabaseMethods _data = new DatabaseMethods();
            var items = _data.GetAllActions();
            string[] splitreqs = requirement.Split(' ');
            int intreturn = 0, intSuffix = 1;
            if (!string.IsNullOrEmpty(requirement))
            {
               
                foreach (var item in items)
                {
                    if (requirement.Contains(item.ActionName))
                    {

                        int x = GetIndexOfArray(item.ActionName, splitreqs);

                        for (int i = 0; i < splitreqs.Length; i++)
                        {
                            if (item.ActionName == splitreqs[i])
                            {
                                bool isInt = int.TryParse(splitreqs[i + 1], out intreturn);

                                specs.Add(new Specifications
                                {
                                    sortid = i,
                                    SpecificationAction = "FS_"+Convert.ToString(intSuffix)+ " : " + item.ActionName,
                                    Action = item.ActionName,
                                    Mechanism =
                                    isInt ?  "IF " + item.ActionMechanism + " " + splitreqs[i + 1] + " THEN Thea shall notify with a voice message - you " + item.ActionName +"ed " + splitreqs[i + 1]   + " " + splitreqs[i + 2]
                                           : "IF " + item.ActionMechanism + " " + splitreqs[i + 1] + " THEN Thea shall notify with a voice message - you " + item.ActionName + "ed " + splitreqs[i + 1]
                                });
                                intSuffix = intSuffix + 1;
                                splitreqs[i] = splitreqs[i] + "XXXX";
                            }
                        }
                        
                    }
                }
            }           


            tblSpecifications.ItemsSource = specs.OrderBy(t=> t.sortid).ToList();


        }

        public int GetIndexOfArray(string Element, string[] Array)
        {
            for (int i = 0; i < Array.Length; i++)
            {
                if (Element == Array[i])
                {
                    return i;
                }
            }
            return -1;
        }
    }
}
