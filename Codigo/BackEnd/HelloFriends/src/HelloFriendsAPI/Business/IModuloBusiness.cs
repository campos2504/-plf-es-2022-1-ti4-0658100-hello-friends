using HelloFriendsAPI.Model;
using HelloFriendsAPI.ViewModels;
using System.Collections.Generic;

namespace HelloFriendsAPI.Business {
    public interface IModuloBusiness {
        Modulo Create(ModuloViewModel modulo);
        Modulo FindByID(long id);
        List<Modulo> FindAll();
        Modulo Update(ModuloViewModel modulo);
        void Delete(long id);
    }
}
