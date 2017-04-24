using BusinessLayer.Implementation;
using CommonLayer.CommonModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace JamiatAhleHadees.Areas.BoardMember.Controllers
{
    public class InvolveMemberController : Controller
    {
        private PanelInvolvementModel _PanelInvolvementModel;
        private readonly PanelInvolveBs _PanelInvolveBs;

        public InvolveMemberController()
        {
            _PanelInvolvementModel = new PanelInvolvementModel();
            _PanelInvolveBs = new PanelInvolveBs();
        }

        // GET: BoardMember/InvolveMember
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Involve(List<int> Involve, int RequestSubmitId,int RequestTypeId)
        {
            UserRegistrationBs obj = new UserRegistrationBs();
            StringBuilder sb = new StringBuilder();
            int check = 0;
            var Userid = obj.UserRegistrationList().Where(x => x.UserName == User.Identity.Name).FirstOrDefault().Id;
            foreach (var item in Involve)
            {
                _PanelInvolvementModel.UserId = Userid;
                _PanelInvolvementModel.UserTypeId = item; 
                _PanelInvolvementModel.RequestSubmitId = RequestSubmitId;
                _PanelInvolvementModel.CreatedDate = Convert.ToDateTime(System.DateTime.Now);
                bool isAlreadyInvolved = _PanelInvolveBs.IsAlreadyExists(_PanelInvolvementModel);
                if (!isAlreadyInvolved)
                {
                    _PanelInvolveBs.Save(_PanelInvolvementModel);
                }
                else
                {
                    check++;
                    if (check==1)
                    {
                        sb.Append("Already exists in the panel(s): \n");
                    }
                   // sb.Append(item.Value);
                }

            }
            if (!string.IsNullOrWhiteSpace(sb.ToString()))
            {
                TempData["AlreadyExistsInPanel"] = sb.ToString();
            }
            else
            {
                TempData["AlreadyExistsInPanel"] = string.Empty;
            }
            return RedirectToAction("GetDetailsbyId", "RequestList",new {Id=@RequestSubmitId,RequestTypeId= @RequestTypeId });
        }
    }
}