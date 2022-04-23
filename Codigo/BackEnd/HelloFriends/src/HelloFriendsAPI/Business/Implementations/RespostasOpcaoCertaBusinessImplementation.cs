using AutoMapper;
using HelloFriendsAPI.Model;
using HelloFriendsAPI.Repositorys.Implementations;
using HelloFriendsAPI.ViewModels;
using System.Collections.Generic;

namespace HelloFriendsAPI.Business.Implementations
{
        public class RespostasOpcaoCertaBusinessImplementation : IRespostasOpcaoCertaBusiness
        {
            private readonly IRespostasOpcaoCertaRepository _repository;
            private readonly IMapper _mapper;

            public RespostasOpcaoCertaBusinessImplementation(IRespostasOpcaoCertaRepository repository, IMapper mapper)
            {
                _repository = repository;
                _mapper = mapper;
            }

            public RespostasOpcaoCerta Create(RespostasOpcaoCertaViewModel respostasOpcaoCertaView)
            {

                //Converção da ViewModel para Model
                return _repository.Create(_mapper.Map<RespostasOpcaoCerta>(respostasOpcaoCertaView));
            }

            public void Delete(long id)
            {

                _repository.Delete(id);
            }

            public List<RespostasOpcaoCerta> FindAll()
            {

                return _repository.FindAll();
            }

            public RespostasOpcaoCerta FindByID(long id)
            {

                return _repository.FindByID(id);
            }

            public RespostasOpcaoCerta Update(RespostasOpcaoCertaViewModel respostasOpcaoCertaView)
            {

                return _repository.Update(_mapper.Map<RespostasOpcaoCerta>(respostasOpcaoCertaView));
            }
        }
    }
