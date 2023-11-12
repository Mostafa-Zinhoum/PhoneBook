using Elfie.Serialization;
using Humanizer.Localisation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.DotNet.Scaffolding.Shared.Messaging;
using Microsoft.Extensions.Localization;
using PhB.Data;
using PhB.Services;
using PhB.Services.Localization;
using PhB.Web.Models;

namespace PhB.Web.Controllers
{
    [Authorize]
    public class PhoneBookController : Controller
    {
        private readonly IPhoneBookService service;
        private readonly IJobService jobService;
        private readonly IStringLocalizer<AccountController> localizer;

        public PhoneBookController(IPhoneBookService service, IJobService jobService
            , IStringLocalizer<AccountController> localizer)
        {
            this.service = service;
            this.jobService = jobService;
            this.localizer = localizer;
        }

        public IActionResult Index()
        {
            return View();//service.GetPhoneBookList()
        }
        public IActionResult myData()
        {
            return Json(new { Data = service.GetPhoneBookList() });
        }
        public IActionResult Jobs()
        {
            return Json(jobService.GetJobs());
        }

        public IActionResult Add() 
        {
            //ViewBag.Jobs = jobService.GetJobs();
            return View(new PhoneBookModel());
        }

        [HttpPost]
        public IActionResult Add(PhoneBookModel phoneBook)
        {
            if(ModelState.IsValid)
            {
                
                service.Create(phoneBook.Image,new PhoneBook 
                { Address = phoneBook.Address,
                Birthday = phoneBook.Birthday,
                JobId = phoneBook.JobId,
                name = phoneBook.name,
                Notes = phoneBook.Notes,
                PhoneNo1 = phoneBook.PhoneNo1,
                PhoneNo2 = phoneBook.PhoneNo2}
                );
                
                return Json(new { Success = true, Message = Resource.GetString("SaveSuccess") });
                //return RedirectToAction("Index");
            }           

            return Json(new { Success = false, Message = Resource.GetString("SaveError") });
        }

        public IActionResult Edit(long id) 
        {
            var ph = service.GetPhoneBookData(id);
            return View(new PhoneBookModel
            {
                Address = ph.Address,
                Birthday = ph.Birthday,
                Id = id,
                JobId = ph.JobId,
                name = ph.name,
                Notes = ph.Notes,
                PhoneNo1 = ph.PhoneNo1,
                PhoneNo2 = ph.PhoneNo2,
                ImagePath = Path.Combine(@"\Files\", ph.Image)
            });
        }

        [HttpPost]
        public IActionResult Edit(PhoneBookModel phoneBook)
        {
            if (ModelState.IsValid)
            {
                service.Update(phoneBook.Image, new PhoneBook
                {
                    Id = phoneBook.Id.Value,
                    Address = phoneBook.Address,
                    Birthday = phoneBook.Birthday,
                    JobId = phoneBook.JobId,
                    name = phoneBook.name,
                    Notes = phoneBook.Notes,
                    PhoneNo1 = phoneBook.PhoneNo1,
                    PhoneNo2 = phoneBook.PhoneNo2
                });
                return RedirectToAction("Index");
            }
            return View(phoneBook);
        }

        public IActionResult Delete(long id)
        {
            service.Delete(id);
            return Json(new { Data = service.GetPhoneBookList() }); 
        }
    }
}
