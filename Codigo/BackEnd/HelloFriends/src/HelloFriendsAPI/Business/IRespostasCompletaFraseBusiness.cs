using HelloFriendsAPI.Model;
using HelloFriendsAPI.ViewModels;
using System;
using System.Collections.Generic;

namespace HelloFriendsAPI.Business.Implementations
{
    public interface IRespostasCompletaFraseBusiness
    {
        RespostasCompleFrase Create(RespostasCompleFraseViewModel respostasViewModel);
        List<RespostasCompleFrase> FindByModuloAluno(long idModulo, long idAluno);
        List<RespostasCompleFrase> FindAll();
        RespostasCompleFrase Update(RespostasCompleFraseViewModel respostasViewModel);
        void Delete(long id);
    }
}
