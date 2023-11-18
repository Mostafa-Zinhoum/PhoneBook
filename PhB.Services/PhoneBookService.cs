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
        private readonly IRepository<PhoneBook_Image> repoImg;
        private readonly IUnitOfWork unitOfWork;
        public PhoneBookService(IUnitOfWork unitOfWork) 
        {
            this.unitOfWork = unitOfWork;
            repo = this.unitOfWork.Repository<PhoneBook>();
            repoImg = this.unitOfWork.Repository<PhoneBook_Image>();
        }

        public IEnumerable<PhoneBook> GetPhoneBookList() 
        {
            return repo.Get(includeProperties: "Job,Governorate,Center");
        }
        public PhoneBook GetPhoneBookData(long id)
        {
            return repo.Get(x=>x.Id == id,includeProperties: "Job,Governorate,Center,Images").FirstOrDefault();
            //return repo.GetByID(id);
        }
        public void Create(List<IFormFile> files,PhoneBook phoneBook)
        {

            
            var imgs = UploadFile(files);
            if (phoneBook.Images == null)
                phoneBook.Images = new List<PhoneBook_Image>();

            foreach (PhoneBook_Image file in imgs)
            {
                file.PhoneBook = phoneBook;
                phoneBook.Images.Add(file);
                //repoImg.Insert(file);
            }
            //repo.SaveChanges();
            repo.Insert(phoneBook);
            unitOfWork.Commit();
        }
        public void Update(List<IFormFile> files,PhoneBook phoneBook)
        {
            
            var imgs = UploadFile(files);

            if (phoneBook.Images == null)
                phoneBook.Images = new List<PhoneBook_Image>();

            foreach (PhoneBook_Image file in imgs)
            {
                file.PhoneBookId = phoneBook.Id;
                //repoImg.Insert(file);
                phoneBook.Images.Add(file);
            }
            repo.Update(phoneBook);
            unitOfWork.Commit();
        }
        public void Delete(long id)
        {
            repo.Delete(id);
            repo.SaveChanges();
        }

        List<PhoneBook_Image> UploadFile(List<IFormFile> files)
        {
            if(files == null)
                return new List<PhoneBook_Image>();

            List < PhoneBook_Image > images = new List<PhoneBook_Image>();
            string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Files");

            //create folder if not exist
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);

            foreach (IFormFile file in files)
            {
                //get file extension
                FileInfo fileInfo = new FileInfo(file.FileName);
                string fileName = Guid.NewGuid() + fileInfo.Extension;

                string fileNameWithPath = Path.Combine(path, fileName);

                using (var stream = new FileStream(fileNameWithPath, FileMode.Create))
                {
                    file.CopyTo(stream);
                }
                images.Add(new PhoneBook_Image { Image = fileName, ImageName = file.FileName });
            }
            return images;
        }
    }
}
