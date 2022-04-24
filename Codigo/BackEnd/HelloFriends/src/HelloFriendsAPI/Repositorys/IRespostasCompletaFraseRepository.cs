using HelloFriendsAPI.Model;
using System;
using System.Collections.Generic;

namespace HelloFriendsAPI.Repositorys.Implementations
{
    public interface IRespostasCompletaFraseRepository
    {
        RespostasCompleFrase Create(RespostasCompleFrase respostasCompleFrase);
        RespostasCompleFrase FindByID(long id);
        RespostasCompleFrase FindByAlunoAtividade(long idAluno, Guid idAtividade);
        List<RespostasCompleFrase> FindByModuloAluno(long idModulo, long idAluno);
        List<RespostasCompleFrase> FindAll();
        RespostasCompleFrase Update(RespostasCompleFrase respostasOpcaoCerta);
        void Delete(long id);
        bool Exists(long id);
    }
}
