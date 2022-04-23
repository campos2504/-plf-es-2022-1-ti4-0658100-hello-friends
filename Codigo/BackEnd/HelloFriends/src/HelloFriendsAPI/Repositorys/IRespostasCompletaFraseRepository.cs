using HelloFriendsAPI.Model;
using System;
using System.Collections.Generic;

namespace HelloFriendsAPI.Repositorys.Implementations
{
    public interface IRespostasCompletaFraseRepository
    {
        RespostasCompleFrase Create(RespostasCompleFrase respostasCompleFrase);
        RespostasCompleFrase FindByID(long id);
        List<RespostasCompleFrase> FindAll();
        RespostasCompleFrase Update(RespostasCompleFrase respostasOpcaoCerta);
        void Delete(long id);
        bool Exists(long id);
    }
}
