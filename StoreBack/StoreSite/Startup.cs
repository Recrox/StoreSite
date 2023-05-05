using Business.Domains;
using Database;
using Database.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Text;

namespace StoreSite;

public class Startup
{
    public IConfiguration Configuration { get; }

    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    // This method gets called by the runtime. Use this method to add services to the container.
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddControllers();

        services.AddTransient<IProductDomain, ProductDomain>();
        services.AddTransient<IProductRepository, ProductRepository>();

        services.AddTransient<IOrderDomain, OrderDomain>();
        services.AddTransient<IOrderRepository, OrderRepository>();

        services.AddTransient<IOrderProductDomain, OrderProductDomain>();
        services.AddTransient<IOrderProductRepository, OrderProductRepository>();

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

        services.AddSwaggerGen(options =>
        {
            options.SwaggerDoc("v1", new OpenApiInfo { Title = "VotreApplication", Version = "v1" });
            AddSecurityDefinition(options);
            AddSecurityRequirement(options);
        });

        ConfigJWT(services);

        services.AddAutoMapper(config =>
        {
            config.CreateMap<WeatherForecastSuchParam, Technocite.Irm.Weather.Site.ViewModels.WeatherForecastSuchParam>().ReverseMap();
            config.CreateMap<Technocite.Irm.Weather.Site.ViewModels.WeatherForecastSuchParam, Technocite.Irm.Weather.Core.Models.WeatherForecastSuchParam>();
        });
    }

    private static void AddSecurityRequirement(SwaggerGenOptions options)
    {
        options.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Id = JwtBearerDefaults.AuthenticationScheme,
                                Type = ReferenceType.SecurityScheme
                            }
                        },
                        new List<string>()
                    }
                });
    }

    private static void AddSecurityDefinition(SwaggerGenOptions options)
    {
        options.AddSecurityDefinition(JwtBearerDefaults.AuthenticationScheme, new OpenApiSecurityScheme
        {
            Scheme = JwtBearerDefaults.AuthenticationScheme,
            BearerFormat = "JWT",
            In = ParameterLocation.Header,
            Name = "Authorization",
            Description = "Bearer Authentification with JWT Token",
            Type = SecuritySchemeType.Http
        });
    }

    private void ConfigJWT(IServiceCollection services)
    {
        // Récupération de la clé secrète depuis la configuration
        string secretKey = Configuration["Jwt:SecretKey"];

        // Ajout du middleware d'authentification JWT
        services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = Configuration["Jwt:Issuer"],
                    ValidAudience = Configuration["Jwt:Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(secretKey))
                };
            });
    }

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
        app.UseAuthentication();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        });
    }
}