using AutoMapper;
using HelloFriendsAPI.Model;
using HelloFriendsAPI.Repositorys;
using HelloFriendsAPI.ViewModels;
using System;
using System.Collections.Generic;

namespace HelloFriendsAPI.Business.Implementations
{
    public class CompletaTextoBusinessImplementation : ICompletaTextoBusiness
    {
        private readonly ICompletaTextoRepository _repository;
        private readonly IMapper _mapper;

        public CompletaTextoBusinessImplementation(ICompletaTextoRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public CompletaTexto Create(CompletaTextoCreateViewModel completaTexto)
        {
            return _repository.Create(_mapper.Map<CompletaTexto>(completaTexto));
        }

        public void Delete(Guid id)
        {
            _repository.Delete(id);
        }

        public List<CompletaTexto> FindAll()
        {
            return _repository.FindAll();
        }

        public CompletaTexto FindByID(Guid id)
        {
            return _repository.FindByID(id);
        }

        public CompletaTexto Update(CompletaTextoCreateViewModel completaTexto)
        {
            return _repository.Update(_mapper.Map<CompletaTexto>(completaTexto));
        }
    }
}
