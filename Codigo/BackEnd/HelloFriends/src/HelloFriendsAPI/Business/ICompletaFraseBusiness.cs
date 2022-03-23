using HelloFriendsAPI.Model;
using HelloFriendsAPI.ViewModels;
using System.Collections.Generic;
using System;

namespace HelloFriendsAPI.Business
{
    public interface ICompletaFraseBusiness
    {
        CompletaFrase Create(CompletaFraseCreateViewModel completaFrase);
        CompletaFrase FindByID(Guid id);
        List<CompletaFrase> FindAll();
        CompletaFrase Update(CompletaFraseCreateViewModel completaFrase);
        void Delete(Guid id);
    }
}
