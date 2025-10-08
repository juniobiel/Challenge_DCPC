using DCPC.Challenge.Escola.Api.Data.Repositories;
using DCPC.Challenge.Escola.Api.Data.Repositories.Interfaces;
using DCPC.Challenge.Escola.Api.Services;
using DCPC.Challenge.Escola.Api.Services.Interfaces;

namespace DCPC.Challenge.Escola.Api.Configuration;

public static class Dependencies
{
    public static IServiceCollection AddDependencyInjections( this IServiceCollection services )
    {
        services.AddScoped<ITokenService, TokenService>();
        services.AddScoped<IAlunoRepository, AlunoRepository>();
        services.AddScoped<IProfessorRepository, ProfessorRepository>();
        services.AddScoped<ICursoRepository, CursoRepository>();
        services.AddScoped<ITurmaRepository, TurmaRepository>();
        services.AddScoped<IMatriculaRepository, MatriculaRepository>();
        services.AddScoped<INotaRepository, NotaRepository>();

        services.AddScoped<IProfessoresService, ProfessoresService>();
        services.AddScoped<ICursosService, CursosService>();
        services.AddScoped<ITurmasService, TurmasService>();
        services.AddScoped<IMatriculasService, MatriculasService>();
        services.AddScoped<INotasService, NotasService>();
        services.AddScoped<IAlunosService, AlunosService>();

        return services;
    }
}
