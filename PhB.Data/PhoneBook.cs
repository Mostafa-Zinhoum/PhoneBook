using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhB.Data
{
    public class PhoneBook : BaseEntity
    {
        public string name { get; set; }
        public DateTime Birthday { get; set; }
        [RegularExpression(@"^01[0-2]\d{1,8}$")]        
        public string PhoneNo1 { get; set; }
        [RegularExpression(@"^01[0-2]\d{1,8}$")]
        public string PhoneNo2 { get; set; }
        public string Address { get; set; }

        [ForeignKey("JobId")]
        public long? JobId { get; set; }
        public Job Job { get; set; }
        public string Notes { get; set; }
        public string Image { get; set; }
    }
}
