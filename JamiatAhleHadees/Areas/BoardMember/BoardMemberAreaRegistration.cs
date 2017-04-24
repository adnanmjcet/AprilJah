using System.Web.Mvc;

namespace JamiatAhleHadees.Areas.BoardMember
{
    public class BoardMemberAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "BoardMember";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "BoardMember_default",
                "BoardMember/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional}
            );
        }
    }
}