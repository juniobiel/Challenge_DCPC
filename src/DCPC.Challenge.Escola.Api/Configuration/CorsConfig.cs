namespace DCPC.Challenge.Escola.Api.Configuration
{
    public static class CorsConfig
    {
        public static IServiceCollection AddCorsPolicies( this IServiceCollection services )
        {
            services.AddCors(options =>
            {
                options.AddPolicy("AllowAll", policy =>
                    policy
                        .AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader());
            });


            return services;
        }
    }
}
