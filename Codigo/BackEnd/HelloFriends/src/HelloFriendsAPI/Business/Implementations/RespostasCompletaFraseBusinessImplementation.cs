using AutoMapper;
using HelloFriendsAPI.Model;
using HelloFriendsAPI.Repositorys.Implementations;
using HelloFriendsAPI.ViewModels;
using System;
using System.Collections.Generic;

namespace HelloFriendsAPI.Business.Implementations
{
        public class RespostasCompletaFraseBusinessImplementation : IRespostasCompletaFraseBusiness
        {
            private readonly IRespostasCompletaFraseRepository _repository;
            private readonly IMapper _mapper;

            public RespostasCompletaFraseBusinessImplementation(IRespostasCompletaFraseRepository repository, IMapper mapper)
            {
                _repository = repository;
                _mapper = mapper;
            }

        public RespostasCompleFrase Create(RespostasCompleFraseViewModel respostasViewModel)
            {
            var consulta = _repository.FindByAlunoAtividade(respostasViewModel.AlunoId, respostasViewModel.CompletaFraseID);
                        
            if (consulta == null)
            {
                return _repository.Create(_mapper.Map<RespostasCompleFrase>(respostasViewModel));
            }
            else
            {
                respostasViewModel.Id = consulta.Id;
                return _repository.Update(_mapper.Map<RespostasCompleFrase>(respostasViewModel));
            }
                
            }

            public void Delete(long id)
            {

                _repository.Delete(id);
            }


            public List<RespostasCompleFrase> FindAll()
            {

                return _repository.FindAll();
            }

        public List<RespostasCompleFrase> FindByModuloAluno(long idModulo, long idAluno)
        {
            return _repository.FindByModuloAluno(idModulo, idAluno);

        }

            public RespostasCompleFrase Update(RespostasCompleFraseViewModel respostasViewModel)
            {

                return _repository.Update(_mapper.Map<RespostasCompleFrase>(respostasViewModel));
            }
        }
    }
