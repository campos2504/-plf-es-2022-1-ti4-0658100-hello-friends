using HelloFriendsAPI.Model;
using Microsoft.EntityFrameworkCore;

namespace HelloFriendsAPI.Repositorys.Data
{
    public class HelloFriendsContext : DbContext
    {
        public HelloFriendsContext()
        {
        }

        public HelloFriendsContext(DbContextOptions<HelloFriendsContext> options) : base(options)
        {
            {

            }
        }

        public DbSet<Aluno> Aluno { get; set; }
        public DbSet<Modulo> Modulo { get; set; }
        public DbSet<CompletaFrase> CompletaFrase { get; set; }
        public DbSet<PalavraChave> PalavraChave { get; set; }
        public DbSet<OpcaoCerta> OpcaoCerta { get; set; }
    }
}