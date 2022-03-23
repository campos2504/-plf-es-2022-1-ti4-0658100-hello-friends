using HelloFriendsAPI.Model;
using HelloFriendsAPI.ViewModels;
using System.Collections.Generic;

namespace HelloFriendsAPI.Business {
    public interface IAlunoBusiness {

        Aluno Create(AlunoViewModel aluno);
        Aluno FindByID(long id);
        List<Aluno> FindAll();
        Aluno Update(Aluno aluno);
        void Delete(long id);
    }
}
