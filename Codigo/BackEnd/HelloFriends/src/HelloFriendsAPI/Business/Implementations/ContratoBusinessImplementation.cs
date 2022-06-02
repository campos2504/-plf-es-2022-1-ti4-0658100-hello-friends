using AutoMapper;
using HelloFriendsAPI.Model;
using HelloFriendsAPI.Repositorys;
using System.Collections.Generic;


namespace HelloFriendsAPI.Business.Implementations
{
    public class ContratoBusinessImplementation : IContratoBusiness
    {
        private readonly IContratoRepository _repository;

        public ContratoBusinessImplementation(IContratoRepository repository)
        {
            _repository = repository;
        }

        public Contrato Create(Contrato contrato) {

            return _repository.Create(contrato);
        }

        public void Delete(long id) {

            _repository.Delete(id);
        }

        public List<Contrato> FindAll() {

            return _repository.FindAll();
        }

        public Contrato FindByID(long id) {

            return _repository.FindByID(id);
        }

        public Contrato Update(Contrato contrato) {

            return _repository.Update(contrato);
        }
    }
}
