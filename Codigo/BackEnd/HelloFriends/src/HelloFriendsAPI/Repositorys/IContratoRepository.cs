using HelloFriendsAPI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HelloFriendsAPI.Repositorys
{
    public interface IContratoRepository
    {
        Contrato Create(Contrato contrato);
        Contrato FindByID(long id);
        List<Contrato> FindAll();
        Contrato Update(Contrato contrato);
        void Delete(long id);
        bool Exists(long id);
       
    }
}
