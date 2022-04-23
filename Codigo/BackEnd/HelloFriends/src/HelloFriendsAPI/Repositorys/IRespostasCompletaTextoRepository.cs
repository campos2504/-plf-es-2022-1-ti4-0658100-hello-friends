using HelloFriendsAPI.Model;
using System;
using System.Collections.Generic;

namespace HelloFriendsAPI.Repositorys.Implementations
{
    public interface IRespostasCompletaTextoRepository
    {
        RespostasCompletaTexto Create(RespostasCompletaTexto respostasCompletaTexto);
        RespostasCompletaTexto FindByID(long id);
        List<RespostasCompletaTexto> FindAll();
        RespostasCompletaTexto Update(RespostasCompletaTexto respostasCompletaTexto);
        void Delete(long id);
        bool Exists(long id);
    }
}
