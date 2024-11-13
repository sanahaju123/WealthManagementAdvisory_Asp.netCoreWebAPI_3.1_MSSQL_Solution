using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace WealthManagementAdvisory.Entities
{
    public class Portfolio
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PortfolioId { get; set; }
        public int UserId { get; set; } 
        public decimal TotalInvestmentValue { get; set; }  
        public decimal PortfolioPerformance { get; set; }  
        public string AssetAllocation { get; set; }
    }
}
