using HelloFriendsAPI.Model;
using HelloFriendsAPI.ViewModels;
using System;
using System.Collections.Generic;

namespace HelloFriendsAPI.Business.Implementations
{
    public interface IRespostasCompletaFraseBusiness
    {
        RespostasCompleFrase Create(RespostasCompleFraseViewModel respostasViewModel);
        RespostasCompleFrase FindByID(long id);
        List<RespostasCompleFrase> FindAll();
        RespostasCompleFrase Update(RespostasCompleFraseViewModel respostasViewModel);
        void Delete(long id);
    }
}
