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
        public long? GovernorateId { get; set; }
        public long? CenterId { get; set; }
        public long? JobId { get; set; }
        public string Notes { get; set; }
        public List<IFormFile> Images { get; set; }
        //public List<PathInfo> ImagePath { get; set; }
    }
    public class PathInfo
    {
        public string FileName { get; set; }
        public string FilePath {  get; set; }
    }
}
