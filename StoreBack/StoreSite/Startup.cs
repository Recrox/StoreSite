using Business.Domains;
using Database;
using Database.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

namespace StoreSite;

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
        services.AddControllers();

        //ConfigJWT(services);

        services.AddTransient<IProductDomain, ProductDomain>();
        services.AddTransient<IProductRepository, ProductRepository>();

        services.AddDbContext<StoreContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("Database"), b => b.MigrationsAssembly("StoreSite")));

        services.AddCors(options =>
        {
            options.AddDefaultPolicy(builder =>
            {
                builder.AllowAnyOrigin()
                        .AllowAnyHeader()
                        .AllowAnyMethod();
            });
        });

        services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo { Title = "VotreApplication", Version = "v1" });
        });
    }

    //private void ConfigJWT(IServiceCollection services)
    //{
    //    // Récupération de la clé secrète depuis la configuration
    //    string secretKey = Configuration["Jwt:SecretKey"];

    //    // Ajout du middleware d'authentification JWT
    //    services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    //        .AddJwtBearer(options =>
    //        {
    //            options.TokenValidationParameters = new TokenValidationParameters
    //            {
    //                ValidateIssuer = true,
    //                ValidateAudience = true,
    //                ValidateLifetime = true,
    //                ValidateIssuerSigningKey = true,
    //                ValidIssuer = "mon_site_web.com",
    //                ValidAudience = "mon_app_client",
    //                IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(secretKey))
    //            };
    //        });
    //}

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "VotreApplication v1"));
        }

        app.UseHttpsRedirection();

        app.UseRouting();

        app.UseCors();

        app.UseAuthorization();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        });
    }
}