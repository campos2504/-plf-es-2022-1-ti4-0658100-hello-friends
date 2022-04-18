using HelloFriendsAPI.Model;
using HelloFriendsAPI.ViewModels;
using Microsoft.AspNetCore.JsonPatch;
using System.Collections.Generic;
using System.Web.Http.OData;

namespace HelloFriendsAPI.Business {
    public interface IAlunoBusiness {

        Aluno Create(AlunoViewModel aluno);
        Aluno FindByID(long id);
        Aluno FindByEmail(string email);
        List<Aluno> FindAll();
        Aluno Update(AlunoViewModel aluno);
        Aluno Autorizar(long id, AlunoAuthViewModel aluno);
        void Delete(long id);
    }
}
