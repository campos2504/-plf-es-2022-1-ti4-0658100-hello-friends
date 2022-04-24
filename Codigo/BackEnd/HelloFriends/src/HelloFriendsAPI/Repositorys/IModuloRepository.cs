using HelloFriendsAPI.Model;
using System.Collections.Generic;

namespace HelloFriendsAPI.Repositorys {
    public interface IModuloRepository {

        Modulo Create(Modulo modulo);
        Modulo FindByID(long id);
        List<Modulo> FindAll();
        Modulo Update(Modulo modulo);
        void Delete(long id);
        bool Exists(long id);
        string FindMedalha(long idModulo, long idAluno);
    }
}
