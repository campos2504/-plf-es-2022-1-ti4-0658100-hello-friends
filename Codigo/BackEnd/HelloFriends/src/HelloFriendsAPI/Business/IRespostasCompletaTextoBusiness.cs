using HelloFriendsAPI.Model;
using HelloFriendsAPI.ViewModels;
using System;
using System.Collections.Generic;

namespace HelloFriendsAPI.Business.Implementations
{
    public interface IRespostasCompletaTextoBusiness
    {
        RespostasCompletaTexto Create(RespostasCompletaTextoViewModel respostasViewModel);
        RespostasCompletaTexto FindByID(long id);
        List<RespostasCompletaTexto> FindAll();
        RespostasCompletaTexto Update(RespostasCompletaTextoViewModel respostasViewModel);
        void Delete(long id);
    }
}
