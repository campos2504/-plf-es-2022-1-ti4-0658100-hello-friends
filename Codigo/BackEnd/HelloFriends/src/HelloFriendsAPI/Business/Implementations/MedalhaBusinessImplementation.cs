using AutoMapper;
using HelloFriendsAPI.Model;
using HelloFriendsAPI.Repositorys.Implementations;
using HelloFriendsAPI.ViewModels;
using System;
using System.Collections.Generic;

namespace HelloFriendsAPI.Business.Implementations
{
        public class MedalhaBusinessImplementation : IMedalhaBusiness
    {
            private readonly IMedalhaRepository _repository;
            private readonly IMapper _mapper;

            public MedalhaBusinessImplementation(IMedalhaRepository repository, IMapper mapper)
            {
                _repository = repository;
                _mapper = mapper;
            }

            public Medalha Create(MedalhaViewModel medalhaViewModel)
            {
            var consulta = _repository.FindByModuloAluno(medalhaViewModel.ModuloId, medalhaViewModel.AlunoId);
                        
            if (consulta == null)
            {
                return _repository.Create(_mapper.Map<Medalha>(medalhaViewModel));
            }
            else
            {
                medalhaViewModel.Id = consulta.Id;
                return _repository.Update(_mapper.Map<Medalha>(medalhaViewModel));
            }
                
            }

            public void Delete(long id)
            {

                _repository.Delete(id);
            }


            public List<Medalha> FindAll()
            {

                return _repository.FindAll();
            }

        public Medalha FindByModuloAluno(long idModulo, long idAluno)
        {
            return _repository.FindByModuloAluno(idModulo, idAluno);

        }

        public Medalha Update(MedalhaViewModel medalhaViewModel)
            {

                return _repository.Update(_mapper.Map<Medalha>(medalhaViewModel));
            }
        }
    }
