using Microsoft.AspNetCore.Http;
using PhB.Data;
using PhB.Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhB.Services
{
    public interface IPhoneBookService
    {
        public IEnumerable<PhoneBook> GetPhoneBookList();
        public PhoneBook GetPhoneBookData(long id);
        public void Create(List<IFormFile> file, PhoneBook phoneBook);
        public void Update(List<IFormFile> file, PhoneBook phoneBook);
        public void Delete(long id);
    }
}
