using HelloFriendsAPI.Model;
using HelloFriendsAPI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HelloFriendsAPI.Business
{
    public interface IContratoBusiness
    {
        Contrato Create(Contrato contrato);
        Contrato FindByID(long id);
        List<Contrato> FindAll();
        Contrato Update(Contrato contrato);
        void Delete(long id);
    }
}
