using HelloFriendsAPI.Model;
using System;
using System.Collections.Generic;

namespace HelloFriendsAPI.Repositorys
{
    public interface ICompletaTextoRepository
    {
        CompletaTexto Create(CompletaTexto completaTexto);
        CompletaTexto FindByID(Guid id);
        List<CompletaTexto> FindAll();
        CompletaTexto Update(CompletaTexto completaTexto);
        void Delete(Guid id);
    }
}
