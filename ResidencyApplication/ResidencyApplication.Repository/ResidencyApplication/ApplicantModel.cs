using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ResidencyApplication.Repository.ResidencyApplication
{
    [Table("Applicant", Schema ="dbo")]
    public class ApplicantModel
    {
        public int id { set; get; }

        public string lastname { set; get; }
        public string firstname { set; get; }
    }
}
