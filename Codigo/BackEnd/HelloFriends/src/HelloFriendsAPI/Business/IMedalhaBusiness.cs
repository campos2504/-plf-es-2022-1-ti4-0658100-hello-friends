using HelloFriendsAPI.Model;
using HelloFriendsAPI.ViewModels;
using System;
using System.Collections.Generic;

namespace HelloFriendsAPI.Business.Implementations
{
    public interface IMedalhaBusiness
    {
        Medalha Create(MedalhaViewModel medalhaViewModel);
        Medalha FindByModuloAluno(long idModulo, long idAluno);
        List<Medalha> FindAll();
        Medalha Update(MedalhaViewModel medalhaViewModel);
        void Delete(long id);
    }
}
