using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace WealthManagementAdvisory.Entities
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserId { get; set; }
        public decimal Income { get; set; }
        public string RiskAppetite { get; set; }
        public string FinancialGoals { get; set; }
    }
}
