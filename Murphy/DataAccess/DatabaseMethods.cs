using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Windows.Forms;
using System.Data;
using Murphy.Models;

namespace Murphy.DataAccess
{
    public class DatabaseMethods
    {
        //private string _conn = ConfigurationManager.ConnectionStrings["MurphyDb"].ConnectionString;
        private string _conn = ConfigurationManager.ConnectionStrings["LocalMSSQLDB"].ConnectionString.Replace(".\\", System.IO.Path.GetDirectoryName(Application.ExecutablePath) + "\\");
        public int AddAgent(string AgentName)
        {
            int id = 0;
            using (SqlConnection conn = new SqlConnection(_conn))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("procAddAgent", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@AgentName", AgentName);

                    id = (int)cmd.ExecuteNonQuery();
                }
                conn.Close();                
            }
            return id;
        }
        
        public int AddAction(string ActionName, int AgentId, string ActionMech, string ActionResp)
        {
            int id = 0;
            using (SqlConnection conn = new SqlConnection(_conn))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("procAddAction", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@AgentId", AgentId);
                    cmd.Parameters.AddWithValue("@ActionName", ActionName);
                    cmd.Parameters.AddWithValue("@ActionMechanism", ActionMech);
                    cmd.Parameters.AddWithValue("@ActionResponse", ActionResp);
                    id = (int)cmd.ExecuteNonQuery();
                }
                conn.Close();
            }
            return id;
        }

        public int AddRisk(string RiskName, int ActionId)
        {
            int id = 0;
            using (SqlConnection conn = new SqlConnection(_conn))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("procAddRisk", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ActionId", ActionId);
                    cmd.Parameters.AddWithValue("@RiskName", RiskName);
                    id = (int)cmd.ExecuteNonQuery();
                }
                conn.Close();
            }
            return id;
        }

        public List<DropdownListItem> GetAllAgents()
        {
            List<DropdownListItem> Items = new List<DropdownListItem>();
            using (SqlConnection conn = new SqlConnection(_conn))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("procGetAllAgents", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    var reader = cmd.ExecuteReader();
                    while (reader.HasRows && reader.Read())
                    {
                        DropdownListItem Item = new DropdownListItem
                        {
                            Id = Convert.ToInt32(reader["AgentId"]),
                            Name = Convert.ToString(reader["AgentName"])
                        };
                        Items.Add(Item);
                    }

                    
                }
                conn.Close();
            }
            return Items;


        }

        public List<DropdownListItem> GetAllActionsDropdown()
        {
            List<DropdownListItem> Items = new List<DropdownListItem>();
            using (SqlConnection conn = new SqlConnection(_conn))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("procGetAllActions", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    var reader = cmd.ExecuteReader();
                    while (reader.HasRows && reader.Read())
                    {
                        DropdownListItem Item = new DropdownListItem
                        {
                            Id = Convert.ToInt32(reader["ActionId"]),
                            Name = Convert.ToString(reader["ActionName"])
                        };
                        Items.Add(Item);
                    }


                }
                conn.Close();
            }
            return Items;


        }
        
        public List<ActionItem> GetAllActions()
        {
            List<ActionItem> actions = new List<ActionItem>();
            using (SqlConnection conn = new SqlConnection(_conn))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("procGetAllActions", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    var reader = cmd.ExecuteReader();
                    while (reader.HasRows && reader.Read())
                    {
                        ActionItem Item = new ActionItem
                        {
                            ActionId = Convert.ToInt32(reader["ActionId"]),
                            ActionName = Convert.ToString(reader["ActionName"]),
                            AgentName = Convert.ToString(reader["AgentName"]),
                            ActionMechanism= Convert.ToString(reader["ActionMechanism"]),
                            ActionRepsonse= Convert.ToString(reader["ActionResponse"]),
                        };
                        actions.Add(Item);
                    }


                }
                conn.Close();
            }
            return actions;
        }

        public List<RiskItem> GetAllRisks()
        {
            List<RiskItem> risks = new List<RiskItem>();
            using (SqlConnection conn = new SqlConnection(_conn))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("procGetAllRisks", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    var reader = cmd.ExecuteReader();
                    while (reader.HasRows && reader.Read())
                    {
                        RiskItem Item = new RiskItem
                        {
                            RiskId = Convert.ToInt32(reader["RiskId"]),
                            RiskName = Convert.ToString(reader["RiskName"]),
                            AgentName = Convert.ToString(reader["AgentName"]),
                            ActionName = Convert.ToString(reader["ActionName"]),
                        };
                        risks.Add(Item);
                    }


                }
                conn.Close();
            }
            return risks;
        }
    }
}
