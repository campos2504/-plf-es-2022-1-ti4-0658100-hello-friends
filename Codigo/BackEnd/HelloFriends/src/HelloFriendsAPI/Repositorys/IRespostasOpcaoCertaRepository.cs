using HelloFriendsAPI.Model;
using System;
using System.Collections.Generic;

namespace HelloFriendsAPI.Repositorys.Implementations
{
    public interface IRespostasOpcaoCertaRepository
    {
        RespostasOpcaoCerta Create(RespostasOpcaoCerta respostasOpcaoCerta);
        RespostasOpcaoCerta FindByID(long id);
        List<RespostasOpcaoCerta> FindAll();
        RespostasOpcaoCerta Update(RespostasOpcaoCerta respostasOpcaoCerta);
        void Delete(long id);
        bool Exists(long id);
        List<RespostasOpcaoCerta> FindByModuloAluno(long idModulo, long idAluno);
        RespostasOpcaoCerta FindByAlunoAtividade(long idAluno, Guid idAtividade);

    }
}
