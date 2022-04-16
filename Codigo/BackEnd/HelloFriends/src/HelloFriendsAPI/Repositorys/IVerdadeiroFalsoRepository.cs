using HelloFriendsAPI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HelloFriendsAPI.Repositorys
{
    public interface IVerdadeiroFalsoRepository
    {
        VerdadeiroFalso Create(VerdadeiroFalso verdadeiroFalso );
        VerdadeiroFalso FindByID(Guid id);
        List<VerdadeiroFalso> FindAll();
        VerdadeiroFalso Update(VerdadeiroFalso verdadeiroFalso);
        void Delete(Guid id);
        bool Exists(Guid id);
    }
}
