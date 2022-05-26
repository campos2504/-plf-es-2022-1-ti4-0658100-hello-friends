using HelloFriendsAPI.Model;
using HelloFriendsAPI.ViewModels;
using System;
using System.Collections.Generic;

namespace HelloFriendsAPI.Business {
    public interface IModuloBusiness {
        Modulo Create(ModuloViewModel modulo);
        Modulo FindByID(long id);
        List<Modulo> FindAll();
        List<ModuloGraficoViewModel> FindMQtdModulosConcluidos();
        Modulo Update(ModuloViewModel modulo);
        void Delete(long id);
        string FindMedalha(long idModulo, long idAluno);
    }
}
