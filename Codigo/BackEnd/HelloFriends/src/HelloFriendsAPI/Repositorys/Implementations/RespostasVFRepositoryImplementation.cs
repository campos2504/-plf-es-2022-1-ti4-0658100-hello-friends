using HelloFriendsAPI.Business.Implementations;
using HelloFriendsAPI.Model;
using HelloFriendsAPI.Repositorys.Data;
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
                return _context.RespostasVF.ToList();
            }

            public RespostasVF FindByID(long id)
            {
                return _context.RespostasVF.SingleOrDefault(p => p.Id.Equals(id));
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
