using DCPC.Challenge.Escola.Api.Configuration;

namespace DCPC.Challenge.Escola.Api;

public class Startup
{
    public IConfiguration Configuration { get; }

    public Startup( IHostEnvironment hostEnvironment )
    {
        var builder = new ConfigurationBuilder()
            .SetBasePath(hostEnvironment.ContentRootPath)
            .AddJsonFile("appsettings.json", true, true)
            .AddJsonFile($"appsettings.{hostEnvironment.EnvironmentName}.json", true, true)
            .AddEnvironmentVariables();

        Configuration = builder.Build();
    }

    public void ConfigureServices( IServiceCollection services )
    {
        services.AddControllers();
        services.AddSwaggerConfig();

        services.AddDbConfig(Configuration);
        services.AddIdentityConfig();
        services.AddAuthenticationConfig(Configuration);
        services.AddDependencyInjections();
    }

    public void Configure( IApplicationBuilder app, IHostEnvironment env )
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseRouting();
        app.UseHttpsRedirection();
        app.UseHsts();
        app.UseAuthentication();
        app.UseAuthorization();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        });

    }
}
