using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Murphy.Models
{
    public class RiskItem
    {
        public int RiskId { get; set; }

        public string RiskName { get; set; }

        public string ActionName { get; set; }

        public string AgentName { get; set; }
    }
}
