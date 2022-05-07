using HelloFriendsAPI.Model;
using System;
using System.Collections.Generic;

namespace HelloFriendsAPI.Repositorys.Implementations
{
    public interface IMedalhaRepository
    {
        Medalha Create(Medalha medalha);
        Medalha FindByID(long id);
        Medalha FindByModuloAluno(long idModulo, long idAluno);
        List<Medalha> FindAll();
        Medalha Update(Medalha medalha);
        void Delete(long id);
        bool Exists(long id);
    }
}
