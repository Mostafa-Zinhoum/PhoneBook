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
    public class PhoneBookService : IPhoneBookService
    {
        private readonly IRepository<PhoneBook> repo;
        public PhoneBookService(IRepository<PhoneBook> repo) 
        {
            this.repo = repo;
        }

        public IEnumerable<PhoneBook> GetPhoneBookList() 
        {
            return repo.Get(includeProperties:"Job");
        }
        public PhoneBook GetPhoneBookData(long id)
        {
            return repo.GetByID(id);
        }
        public void Create(IFormFile file,PhoneBook phoneBook)
        {
            phoneBook.Image = UploadFile(file);
            repo.Insert(phoneBook);
            repo.SaveChanges();
        }
        public void Update(IFormFile file,PhoneBook phoneBook)
        {
            phoneBook.Image = UploadFile(file);
            repo.Update(phoneBook);
            repo.SaveChanges();
        }
        public void Delete(long id)
        {
            repo.Delete(id);
            repo.SaveChanges();
        }

        string UploadFile(IFormFile file)
        {
            if(file == null)
                return string.Empty;
            string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Files");

            //create folder if not exist
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);

            //get file extension
            FileInfo fileInfo = new FileInfo(file.FileName);
            string fileName = DateTime.Now.ToString("yyyyMMddHHmmssffff") + fileInfo.Extension;

            string fileNameWithPath = Path.Combine(path, fileName);

            using (var stream = new FileStream(fileNameWithPath, FileMode.Create))
            {
                file.CopyTo(stream);
            }
            return fileName;
        }
    }
}
