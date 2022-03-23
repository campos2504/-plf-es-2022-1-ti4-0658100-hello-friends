using AutoMapper;
using HelloFriendsAPI.Model;
using HelloFriendsAPI.Repositorys;
using HelloFriendsAPI.ViewModels;
using System.Collections.Generic;

namespace HelloFriendsAPI.Business.Implementations {
    public class AlunoBusinessImplementation : IAlunoBusiness {

        private readonly IAlunoRepository _repository;
        private readonly IMapper _mapper;

        public AlunoBusinessImplementation(IAlunoRepository repository, IMapper mapper) {
            _repository = repository;
            _mapper = mapper;
        }

        public Aluno Create(AlunoViewModel alunoViewModel) {

            //Converção da ViewModel para Model
            return _repository.Create(_mapper.Map<Aluno>(alunoViewModel));
        }

        public void Delete(long id) {

            _repository.Delete(id);
        }

        public List<Aluno> FindAll() {

            return _repository.FindAll();
        }

        public Aluno FindByID(long id) {

            return _repository.FindByID(id);
        }

        public Aluno Update(Aluno aluno) {

            return _repository.Update(aluno);
        }
    }
}
