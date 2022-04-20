using AutoMapper;
using HelloFriendsAPI.Model;
using HelloFriendsAPI.Repositorys;
using HelloFriendsAPI.ViewModels;
using System;
using System.Collections.Generic;


namespace HelloFriendsAPI.Business.Implementations
{
    public class VerdadeiroFalsoBusinessImplementation : IVerdadeiroFalsoBusiness
    {
        private readonly IVerdadeiroFalsoRepository _repository;
        private readonly IMapper _mapper;

        public VerdadeiroFalsoBusinessImplementation(IVerdadeiroFalsoRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public VerdadeiroFalso Create(VerdadeiroFalsoCreateViewModel verdadeiroFalsoCreateViewModel) {

            //Converção da ViewModel para Model
            return _repository.Create(_mapper.Map<VerdadeiroFalso>(verdadeiroFalsoCreateViewModel));
        }

        public void Delete(Guid id) {

            _repository.Delete(id);
        }

        public List<VerdadeiroFalso> FindAll() {

            return _repository.FindAll();
        }

        public VerdadeiroFalso FindByID(Guid id) {

            return _repository.FindByID(id);
        }

        public VerdadeiroFalso Update(VerdadeiroFalsoCreateViewModel verdadeiroFalsoCreateViewModel) {

            return _repository.Update(_mapper.Map<VerdadeiroFalso>(verdadeiroFalsoCreateViewModel));
        }
    }
}
