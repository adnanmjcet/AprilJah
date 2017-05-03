﻿using BusinessLayer.Implementation;
using CommonLayer.CommonModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JamiatAhleHadees.Areas.Admin.Controllers
{
    public class PostNotificationController : Controller
    {
        private readonly UserModel _userModel;
        private readonly UserRegistrationBs _userRegistrationBs;

        public PostNotificationController()
        {
            _userModel = new UserModel();
            _userRegistrationBs = new UserRegistrationBs();
        }
        // GET: Admin/PostNotification
        public ActionResult Index()
        {
            ViewBag.CategoryList = new SelectList(_userRegistrationBs.CategoryList(), "Id", "Name");
            return View();
        }

        [HttpPost]
        public ActionResult Index(string notificationMessage, int? CategoryID)
        {
            _userRegistrationBs.SendPushNotification(notificationMessage,CategoryID);
            ViewBag.CategoryList = new SelectList(_userRegistrationBs.CategoryList(), "Id", "Name");
            return View();
        }
    }
}