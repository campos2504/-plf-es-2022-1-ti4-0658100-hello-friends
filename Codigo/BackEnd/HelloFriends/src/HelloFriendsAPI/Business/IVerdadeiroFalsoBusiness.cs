using HelloFriendsAPI.Model;
using HelloFriendsAPI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HelloFriendsAPI.Business
{
    public interface IVerdadeiroFalsoBusiness
    {
        VerdadeiroFalso Create(VerdadeiroFalsoCreateViewModel verdadeiroFalsoView);
        VerdadeiroFalso FindByID(Guid id);
        List<VerdadeiroFalso> FindAll();
        VerdadeiroFalso Update(VerdadeiroFalsoCreateViewModel verdadeiroFalsoView);
        void Delete(Guid id);
    }
}
