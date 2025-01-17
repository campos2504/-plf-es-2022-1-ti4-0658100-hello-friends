﻿using HelloFriendsAPI.Model;
using System.Collections.Generic;
using HelloFriendsAPI.ViewModels;

namespace HelloFriendsAPI.Repositorys {
    public interface IAlunoRepository {

        Aluno Create(Aluno aluno);
        Aluno FindByID(long id);
        List<Aluno> FindAll();
        Aluno Update(Aluno aluno);
        void Delete(long id);
        bool Exists(long id);
        Aluno FindByEmail(string email);
        AlunoMediaViewModel FindMediaAluno(Aluno aluno);
        List<AlunoAtividadeViewModel> FindAlunoMediaAtividade(Aluno aluno);
    }
}
