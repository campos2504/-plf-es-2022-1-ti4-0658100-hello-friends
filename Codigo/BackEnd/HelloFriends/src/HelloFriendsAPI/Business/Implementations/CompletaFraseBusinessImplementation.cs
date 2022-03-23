using AutoMapper;
using HelloFriendsAPI.Model;
using HelloFriendsAPI.Repositorys;
using HelloFriendsAPI.ViewModels;
using System;
using System.Collections.Generic;

namespace HelloFriendsAPI.Business.Implementations
{
    public class CompletaFraseBusinessImplementation : ICompletaFraseBusiness
    {
        private readonly ICompletaFraseRepository _repository;
        private readonly IMapper _mapper;

        public CompletaFraseBusinessImplementation(ICompletaFraseRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public CompletaFrase Create(CompletaFraseCreateViewModel completaFrase)
        {
            return _repository.Create(_mapper.Map<CompletaFrase>(completaFrase));
        }

        public void Delete(Guid id)
        {
            _repository.Delete(id);
        }

        public List<CompletaFrase> FindAll()
        {
            return _repository.FindAll();
        }

        public CompletaFrase FindByID(Guid id)
        {
            return _repository.FindByID(id);
        }

        public CompletaFrase Update(CompletaFraseCreateViewModel completaFrase)
        {
            return _repository.Update(_mapper.Map<CompletaFrase>(completaFrase));
        }
    }
}
