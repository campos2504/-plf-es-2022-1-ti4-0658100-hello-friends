using AutoMapper;
using HelloFriendsAPI.Model;
using HelloFriendsAPI.Repositorys;
using HelloFriendsAPI.ViewModels;
using System;
using System.Collections.Generic;

namespace HelloFriendsAPI.Business.Implementations {
    public class ModuloBusinessImplementation : IModuloBusiness{

        private readonly IModuloRepository _repository;
        private readonly IMapper _mapper;

        public ModuloBusinessImplementation(IModuloRepository repository, IMapper mapper) {
            _repository = repository;
            _mapper = mapper;
        }

        public Modulo Create(ModuloViewModel moduloViewModel) {

            //Converção da ViewModel para Model
            return _repository.Create(_mapper.Map<Modulo>(moduloViewModel));
        }

        public void Delete(long id) {

            _repository.Delete(id);
        }

        public List<Modulo> FindAll() {

            return _repository.FindAll();
        }

        public Modulo FindByID(long id) {

            return _repository.FindByID(id);
        }

        public Modulo Update(ModuloViewModel moduloViewModel) {

            return _repository.Update(_mapper.Map<Modulo>(moduloViewModel));

        }

        public string FindMedalha(long idModulo, long idAluno)
        {
            return _repository.FindMedalha(idModulo, idAluno);
        }

        public List<ModuloGraficoViewModel> FindMQtdModulosConcluidos()
        {
            return _repository.FindMQtdModulosConcluidos();
        }
    }
}
