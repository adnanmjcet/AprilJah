using System.Web.Mvc;

namespace JamiatAhleHadees.Areas.PanelMember
{
    public class PanelMemberAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "PanelMember";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "PanelMember_default",
                "PanelMember/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}