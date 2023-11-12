using PhB.Data;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PhB.Web.Models
{
    public class PhoneBookModel
    {
        public long? Id { get; set; }
        public string name { get; set; }
        public DateTime Birthday { get; set; }
        [RegularExpression(@"^01[0-2]\d{1,8}$")]
        public string PhoneNo1 { get; set; }
        [RegularExpression(@"^01[0-2]\d{1,8}$")]
        public string PhoneNo2 { get; set; }
        public string Address { get; set; }
        public long? JobId { get; set; }
        public string Notes { get; set; }
        public IFormFile? Image { get; set; }
        public string? ImagePath { get; set; }
    }
}
