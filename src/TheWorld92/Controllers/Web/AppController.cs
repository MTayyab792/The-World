﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using TheWorld92.ViewModels;
using TheWorld92.Services;
using TheWorld92.Models;
using Microsoft.AspNet.Authorization;


// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace TheWorld92.Controllers.Web
{
    public class AppController : Controller
    {
        private IMailService _mailService;
        private IWorldRepository _respository;

        public AppController(IMailService service, IWorldRepository repository)
        {
            _mailService = service;
            _respository = repository;
        }
        public IActionResult Index()
        {
           
            return View();
        }
        [Authorize]
        public IActionResult Trips()
        {
           
            return View();
        }
        public IActionResult About()
        {
            return View();
        }
        public IActionResult Contact()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Contact(ContactViewModel model)
        {
            if (ModelState.IsValid) { 
            var email = Startup.Configuration["AppSettings:SiteEmailAddress"];
                if (string.IsNullOrWhiteSpace(email))
                {
                    ModelState.AddModelError("", "Could not send email, configration problem");
                }

                if(_mailService.SendMail("email",
                "email",
                $"Contact Page from {model.Name} ({model.Email})",
                model.Message))
                {
                    ModelState.Clear();
                    ViewBag.Message = "Mail Sent. Thanks!"; 
                }
            }
            return View();
        }
    }
}
