using HelloFriendsAPI.Model;
using HelloFriendsAPI.ViewModels;
using System.Collections.Generic;
using System;

namespace HelloFriendsAPI.Business
{
    public interface ICompletaTextoBusiness
    {
        CompletaTexto Create(CompletaTextoCreateViewModel completaTexto);
        CompletaTexto FindByID(Guid id);
        List<CompletaTexto> FindAll();
        CompletaTexto Update(CompletaTextoCreateViewModel completaTexto);
        void Delete(Guid id);
    }
}
