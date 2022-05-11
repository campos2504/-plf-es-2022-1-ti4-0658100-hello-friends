using AutoMapper;
using HelloFriendsAPI.Model;
using HelloFriendsAPI.Repositorys;
using HelloFriendsAPI.ViewModels;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Web.Http.ModelBinding;
using System.Web.Http.OData;

namespace HelloFriendsAPI.Business.Implementations {
    public class AlunoBusinessImplementation : IAlunoBusiness
    {

        private readonly IAlunoRepository _repository;
        private readonly IMapper _mapper;

        public List<AlunoMediaViewModel> GetMedia()
        {
            var alunos =_repository.FindAll();
            var alunosMediaList = new List<AlunoMediaViewModel>();
            foreach (var aluno in alunos)
            {
                var media = _repository.FindMediaAluno(aluno.Id);
                var alunoMedia = new AlunoMediaViewModel();
                alunoMedia.Id = aluno.Id;
                alunoMedia.NomeCompleto = aluno.NomeCompleto;
                alunoMedia.Media = media;
                alunosMediaList.Add(alunoMedia);
            }

            return alunosMediaList;
        }
        public AlunoBusinessImplementation(IAlunoRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public Aluno Create(AlunoViewModel alunoViewModel)
        {

            //Converção da ViewModel para Model
            return _repository.Create(_mapper.Map<Aluno>(alunoViewModel));
        }

        public void Delete(long id)
        {

            _repository.Delete(id);
        }

        public List<Aluno> FindAll()
        {

            return _repository.FindAll();
        }

        public Aluno FindByID(long id)
        {

            return _repository.FindByID(id);
        }

        public Aluno Update(AlunoViewModel alunoViewModel)
        {
            if(alunoViewModel.Imagem == null)
            {
                var alunoSelecionado = _repository.FindByID(alunoViewModel.Id);
                alunoViewModel.Imagem = alunoSelecionado.Imagem;
            }            

            return _repository.Update(_mapper.Map<Aluno>(alunoViewModel));
        }

        public Aluno Autorizar(long id, AlunoAuthViewModel aluno)
        {
            var alunoSelecionado = _repository.FindByID(id);

            alunoSelecionado.Status = aluno.Status;
            alunoSelecionado.Situacao = aluno.Situacao;

            return _repository.Update(alunoSelecionado);
        }

        public Aluno FindByEmail(string email)
        {
            return _repository.FindByEmail(email);
        }
    }
}
