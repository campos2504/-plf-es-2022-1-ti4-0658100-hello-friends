using HelloFriendsAPI.Model;
using HelloFriendsAPI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HelloFriendsAPI.Business
{
    public interface IOpcaoCertaBusiness
    {
        OpcaoCerta Create(OpcaoCertaCreateViewModel opcaoCerta);
        OpcaoCerta FindByID(Guid id);
        List<OpcaoCerta> FindAll();
        OpcaoCerta Update(OpcaoCertaCreateViewModel opcaoCerta);
        void Delete(Guid id);
    }
}
