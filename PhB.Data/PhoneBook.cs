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
        [ForeignKey("GovernorateId")]
        public long? GovernorateId { get; set; }
        public Governorate? Governorate { get; set; }

        [ForeignKey("CenterId")]
        public long? CenterId { get; set; }
        public Center? Center { get; set; }
        public string Address { get; set; }

        [ForeignKey("JobId")]
        public long? JobId { get; set; }
        public Job Job { get; set; }
        public string Notes { get; set; }
        public List<PhoneBook_Image> Images { get; set; }
    }

    public class PhoneBook_Image : BaseEntity
    {
        [ForeignKey("PhoneBookId")]
        public long? PhoneBookId { get; set; }
        public PhoneBook? PhoneBook { get; set; }
        public string Image { get; set; }
        public string ImageName { get; set; }
    }
}
