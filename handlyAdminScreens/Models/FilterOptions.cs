using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace handlyAdminScreens.Models
{

    public enum CurrentGridType
    {
        Users,
        Transactions,
        Reports
    }

    public class BaseFilterOptions 
    {
        public bool RemoveFilter { get; set; } = false;
    }

    public class UserFilterOptions : BaseFilterOptions
    {
        public string RoleName { get; set; }
        public List<string> Professions { get; set; } = new List<string>();
        public List<string> StateName { get; set; } = new List<string>();
        public int? IsAppUser { get; set; }
        public DateTime? CreatedFromDate { get; set; }
        public DateTime? CreatedToDate { get; set; }
        public DateTime? LastConnectionFromDate { get; set; }
        public DateTime? LastConnectionToDate { get; set; }
    }

    public class TransactionFilterOptions : BaseFilterOptions 
    {
         public decimal? MinAmount { get; set; }

        public decimal? MaxAmount { get; set; }
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }
    }
}
