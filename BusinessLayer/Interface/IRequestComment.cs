using CommonLayer.CommonModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Interface
{
    public interface IRequestComment
    {
        List<RequestCommentModel> BoardCommentList(int id);

        List<RequestCommentModel> PanelCommentList(int id);

        RequestCommentModel GetDetails(RequestCommentModel model);

        int Save(RequestCommentModel model);

        RequestCommentModel GetById(int id);
    }
}
