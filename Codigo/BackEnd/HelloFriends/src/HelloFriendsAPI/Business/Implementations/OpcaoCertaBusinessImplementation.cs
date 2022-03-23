using AutoMapper;
using HelloFriendsAPI.Model;
using HelloFriendsAPI.Repositorys;
using HelloFriendsAPI.ViewModels;
using System;
using System.Collections.Generic;


namespace HelloFriendsAPI.Business.Implementations
{
    public class OpcaoCertaBusinessImplementation : IOpcaoCertaBusiness
    {
        private readonly IOpcaoCertaRepository _repository;
        private readonly IMapper _mapper;

        public OpcaoCertaBusinessImplementation(IOpcaoCertaRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public OpcaoCerta Create(OpcaoCertaCreateViewModel opcaoCertaViewModel) {

            //Converção da ViewModel para Model
            return _repository.Create(_mapper.Map<OpcaoCerta>(opcaoCertaViewModel));
        }

        public void Delete(Guid id) {

            _repository.Delete(id);
        }

        public List<OpcaoCerta> FindAll() {

            return _repository.FindAll();
        }

        public OpcaoCerta FindByID(Guid id) {

            return _repository.FindByID(id);
        }

        public OpcaoCerta Update(OpcaoCertaCreateViewModel opcaoCertaViewModel) {

            return _repository.Update(_mapper.Map<OpcaoCerta>(opcaoCertaViewModel));
        }
    }
}
