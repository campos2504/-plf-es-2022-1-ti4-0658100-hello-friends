using AutoMapper;
using HelloFriendsAPI.Model;
using HelloFriendsAPI.Repositorys.Implementations;
using HelloFriendsAPI.ViewModels;
using System.Collections.Generic;

namespace HelloFriendsAPI.Business.Implementations
{
        public class RespostasCompletaTextoBusinessImplementation : IRespostasCompletaTextoBusiness
        {
            private readonly IRespostasCompletaTextoRepository _repository;
            private readonly IMapper _mapper;

            public RespostasCompletaTextoBusinessImplementation(IRespostasCompletaTextoRepository repository, IMapper mapper)
            {
                _repository = repository;
                _mapper = mapper;
            }

        public RespostasCompletaTexto Create(RespostasCompletaTextoViewModel respostasViewModel)
            {

                //Converção da ViewModel para Model
                return _repository.Create(_mapper.Map<RespostasCompletaTexto>(respostasViewModel));
            }

            public void Delete(long id)
            {

                _repository.Delete(id);
            }

            public List<RespostasCompletaTexto> FindAll()
            {

                return _repository.FindAll();
            }

            public RespostasCompletaTexto FindByID(long id)
            {

                return _repository.FindByID(id);
            }

            public RespostasCompletaTexto Update(RespostasCompletaTextoViewModel respostasViewModel)
            {

                return _repository.Update(_mapper.Map<RespostasCompletaTexto>(respostasViewModel));
            }
        }
    }
