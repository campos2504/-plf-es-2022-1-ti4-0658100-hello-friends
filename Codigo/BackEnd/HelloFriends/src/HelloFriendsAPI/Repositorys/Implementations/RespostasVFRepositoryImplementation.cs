using HelloFriendsAPI.Business.Implementations;
using HelloFriendsAPI.Model;
using HelloFriendsAPI.Repositorys.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HelloFriendsAPI.Repositorys.Implementations
{
        public class RespostasVFRepositoryImplementation : IRespostasVFRepository
        {
            private HelloFriendsContext _context;

            public RespostasVFRepositoryImplementation(HelloFriendsContext context)
            {
                _context = context;
            }

            public RespostasVF Create(RespostasVF respostasVF)
            {
                try
                {
                    _context.Add(respostasVF);
                    _context.SaveChanges();
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                return respostasVF;
            }

            public void Delete(long id)
            {

                var result = _context.RespostasVF.SingleOrDefault(p => p.Id.Equals(id));

                if (result != null)
                {
                    try
                    {
                        _context.Remove(result);
                        _context.SaveChanges();
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                }
            }

            public bool Exists(long id)
            {
                return _context.RespostasVF.Any(p => p.Id.Equals(id));
            }

            public List<RespostasVF> FindAll()
            {
            var result = _context.RespostasVF.Include(p => p.Aluno).Include(p => p.VerdadeiroFalso).ToList();

            return result;
        }

        public RespostasVF FindByAlunoAtividade(long idAluno, Guid idAtividade)
        {
            return _context.RespostasVF.SingleOrDefault(p => p.AlunoId.Equals(idAluno) && p.VerdadeiroFalsoID.Equals(idAtividade));
        }

        public RespostasVF FindByID(long id)
            {
                return _context.RespostasVF.SingleOrDefault(p => p.Id.Equals(id));
            }

        public List<RespostasVF> FindByModuloAluno(long idModulo, long idAluno)
        {
            return _context.RespostasVF.Where(p => p.MId.Equals(idModulo) && p.AlunoId.Equals(idAluno)).ToList();
        }

        public RespostasVF Update(RespostasVF respostasVF)
            {
                if (!Exists(respostasVF.Id)) return null;

                var result = _context.RespostasVF.SingleOrDefault(p => p.Id.Equals(respostasVF.Id));

                if (result != null)
                {
                    try
                    {
                        _context.Entry(result).CurrentValues.SetValues(respostasVF);
                        _context.SaveChanges();
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                }

                return respostasVF;
            }
        }
    }
