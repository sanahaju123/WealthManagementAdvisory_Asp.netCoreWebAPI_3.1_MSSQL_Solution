using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace WealthManagementAdvisory.Entities
{
    public class Advisory
    {
        public int AdvisoryId { get; set; }

        public int UserId { get; set; }
        public string RecommendationTitle { get; set; }
        public string RecommendationDescription { get; set; }
        public DateTime AdvisoryDate { get; set; }
        public string SessionType { get; set; }
        public string RiskLevel { get; set; }
    }
}
