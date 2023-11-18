using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhB.Data
{
    public class Center : BaseEntity
    {
        public string Name { get; set; }
        [ForeignKey("GovernorateId")]
        public long? GovernorateId { get; set; }
        public Governorate Governorate { get; set; }

    }
}
