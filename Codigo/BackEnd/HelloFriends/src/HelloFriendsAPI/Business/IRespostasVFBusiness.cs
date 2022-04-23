using HelloFriendsAPI.Model;
using HelloFriendsAPI.ViewModels;
using System;
using System.Collections.Generic;

namespace HelloFriendsAPI.Business.Implementations
{
    public interface IRespostasVFBusiness
    {
        RespostasVF Create(RespostasVFViewModel respostasVF);
        RespostasVF FindByID(long id);
        List<RespostasVF> FindAll();
        RespostasVF Update(RespostasVFViewModel respostasVF);
        void Delete(long id);
    }
}
