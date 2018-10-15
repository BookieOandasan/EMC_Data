using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ResidencyApplication.Repository.ResidencyApplication
{
    [Table("Applicant", Schema = "dbo")]
    public class ApplicantModel
    {
        public int id { set; get; }

        public string lastname { set; get; }
        public string firstname { set; get; }
        public int? score { set; get; }
        public string school { set; get; }
        public string email { set; get; }
        public string mobileNumber { set; get; }
        public string interviewSeason { set; get; }
        public int? fiveStarRating { set; get; }
        public int? likes { set; get; }
        public DateTime? interviewDate { set; get; }
        public bool? usGrad { set; get; }
        public string contactPerson { set; get; }
        public string facultyGroup { set; get; }
        public string address1 { set; get; }
        public string address2 { set; get; }
        public string city { set; get; }
        public string state { set; get; }
        public string zip { set; get; }
        public DateTime? lastUpdateDate { set; get; }
        public DateTime? createdDate { set; get; }
        public string lastUpdateBy { set; get; }
        public string createdBy { set; get; }

    }
}
