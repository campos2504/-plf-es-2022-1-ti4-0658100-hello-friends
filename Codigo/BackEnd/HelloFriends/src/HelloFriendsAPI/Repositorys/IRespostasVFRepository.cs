using HelloFriendsAPI.Model;
using System;
using System.Collections.Generic;

namespace HelloFriendsAPI.Repositorys.Implementations
{
    public interface IRespostasVFRepository
    {
        RespostasVF Create(RespostasVF respostasVF);
        RespostasVF FindByID(long id);
        List<RespostasVF> FindAll();
        RespostasVF Update(RespostasVF respostasVF);
        void Delete(long id);
        bool Exists(long id);
    }
}
