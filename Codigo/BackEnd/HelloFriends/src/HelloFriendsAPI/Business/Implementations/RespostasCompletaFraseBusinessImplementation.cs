using AutoMapper;
using HelloFriendsAPI.Model;
using HelloFriendsAPI.Repositorys.Implementations;
using HelloFriendsAPI.ViewModels;
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

                //Converção da ViewModel para Model
                return _repository.Create(_mapper.Map<RespostasCompleFrase>(respostasViewModel));
            }

            public void Delete(long id)
            {

                _repository.Delete(id);
            }

            public List<RespostasCompleFrase> FindAll()
            {

                return _repository.FindAll();
            }

            public RespostasCompleFrase FindByID(long id)
            {

                return _repository.FindByID(id);
            }

            public RespostasCompleFrase Update(RespostasCompleFraseViewModel respostasViewModel)
            {

                return _repository.Update(_mapper.Map<RespostasCompleFrase>(respostasViewModel));
            }
        }
    }
