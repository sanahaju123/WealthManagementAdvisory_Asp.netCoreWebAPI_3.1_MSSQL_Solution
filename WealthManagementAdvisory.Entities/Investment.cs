using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace WealthManagementAdvisory.Entities
{
    public class Investment
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int InvestmentId { get; set; }
        public int UserId { get; set; }
        public decimal Amount { get; set; }
        public string InvestmentType { get; set; }
        public DateTime PurchaseDate { get; set; }
    }
}
