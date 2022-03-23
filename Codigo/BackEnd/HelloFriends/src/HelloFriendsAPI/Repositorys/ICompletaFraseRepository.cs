using HelloFriendsAPI.Model;
using System;
using System.Collections.Generic;

namespace HelloFriendsAPI.Repositorys
{
    public interface ICompletaFraseRepository
    {
        CompletaFrase Create(CompletaFrase completaFrase);
        CompletaFrase FindByID(Guid id);
        List<CompletaFrase> FindAll();
        CompletaFrase Update(CompletaFrase completaFrase);
        void Delete(Guid id);
    }
}
