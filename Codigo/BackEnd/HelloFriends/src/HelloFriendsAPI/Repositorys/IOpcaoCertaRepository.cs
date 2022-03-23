using HelloFriendsAPI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HelloFriendsAPI.Repositorys
{
    public interface IOpcaoCertaRepository
    {
        OpcaoCerta Create(OpcaoCerta opcaoCerta);
        OpcaoCerta FindByID(Guid id);
        List<OpcaoCerta> FindAll();
        OpcaoCerta Update(OpcaoCerta opcaoCerta);
        void Delete(Guid id);
        bool Exists(Guid id);
    }
}
