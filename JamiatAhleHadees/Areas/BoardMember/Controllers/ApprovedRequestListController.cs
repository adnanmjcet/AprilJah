using BusinessLayer.Implementation;
using CommonLayer.CommonModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JamiatAhleHadees.Areas.BoardMember.Controllers
{
    [Authorize(Roles = "BoardMember")]
    public class ApprovedRequestListController : Controller
    {
        private RequestApproveModel _RequestApproveModel;
        private readonly RequestApproveRejectBs _RequestApproveBs;

        public ApprovedRequestListController()
        {
            _RequestApproveModel = new RequestApproveModel();
            _RequestApproveBs = new RequestApproveRejectBs();
        }

        public ActionResult Index()
        {
            var approvedRequestList = _RequestApproveBs.RequestApprovedList().ToList();

            return View(approvedRequestList);
        }

        public ActionResult RejectedList()
        {
            var approvedRequestList = _RequestApproveBs.RequestRejectedList().ToList();

            return View(approvedRequestList);
        }
    }
}