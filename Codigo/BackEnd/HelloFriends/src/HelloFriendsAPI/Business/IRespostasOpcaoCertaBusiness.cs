using HelloFriendsAPI.Model;
using HelloFriendsAPI.ViewModels;
using System;
using System.Collections.Generic;

namespace HelloFriendsAPI.Business.Implementations
{
    public interface IRespostasOpcaoCertaBusiness
    {
        RespostasOpcaoCerta Create(RespostasOpcaoCertaViewModel respostasOpcaoCertaView);
        RespostasOpcaoCerta FindByID(long id);
        List<RespostasOpcaoCerta> FindAll();
        RespostasOpcaoCerta Update(RespostasOpcaoCertaViewModel respostasOpcaoCertaView);
        void Delete(long id);

        List<RespostasOpcaoCerta> FindByModuloAluno(long idModulo, long idAluno);
    }
}
