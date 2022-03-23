using AutoMapper;
using HelloFriendsAPI.Business;
using HelloFriendsAPI.Business.Implementations;
using HelloFriendsAPI.Configuration;
using HelloFriendsAPI.Model;
using HelloFriendsAPI.Repositorys;
using HelloFriendsAPI.Repositorys.Data;
using HelloFriendsAPI.Repositorys.Implementations;
using HelloFriendsAPI.Services;
using HelloFriendsAPI.ViewModels;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using System.IO;

namespace HelloFriendsAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            services.AddCors(oprtions => oprtions.AddDefaultPolicy(builder => {
              builder.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader();
            }));

            services.AddIdentityConfiguration(Configuration);

            services.Configure<MailSettings>(Configuration.GetSection("MailSettings"));//email
            services.AddTransient<IMailService, Services.MailService>();

            services.AddDbContext<HelloFriendsContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"), builder =>
            builder.MigrationsAssembly("HelloFriendsAPI")));

            //Configuração do Mapper
            var configMapper = new MapperConfiguration(cfg => {
                cfg.CreateMap<Aluno, AlunoViewModel>().ReverseMap();
                cfg.CreateMap<Modulo, ModuloViewModel>().ReverseMap();
                cfg.CreateMap<OpcaoCerta, OpcaoCertaCreateViewModel>().ReverseMap();
                cfg.CreateMap<CompletaFrase, CompletaFraseCreateViewModel>().ReverseMap();
                cfg.CreateMap<PalavraChave, PalavraChaveViewModel>().ReverseMap();
            });
            IMapper mapper = configMapper.CreateMapper();

            //Dependency Injection
            services.AddScoped<IAlunoBusiness, AlunoBusinessImplementation>();
            services.AddScoped<IAlunoRepository, AlunoRepositoryImplementation>();
            services.AddScoped<IModuloBusiness, ModuloBusinessImplementation>();
            services.AddScoped<IModuloRepository, ModuloRepositoryImplementation>();
            services.AddScoped<IOpcaoCertaBusiness, OpcaoCertaBusinessImplementation>();
            services.AddScoped<IOpcaoCertaRepository, OpcaoCertaRepositoryImplementation>();
            services.AddScoped<ICompletaFraseBusiness, CompletaFraseBusinessImplementation>();
            services.AddScoped<ICompletaFraseRepository, CompletaFraseRepositoryImplementation>();
            services.AddSingleton(mapper);

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseStaticFiles(new StaticFileOptions
            {
                FileProvider = new PhysicalFileProvider(Path.Combine(env.ContentRootPath, "wwwroot/Images")),
                RequestPath = "/Images"
            }) ;
            app.UseAuthentication();
            app.UseHttpsRedirection();
            app.UseCors();
            app.UseMvc();
        }
    }
}
