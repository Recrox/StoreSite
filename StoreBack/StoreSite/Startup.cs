using Business.Domains;
using Database;
using Database.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using StoreSite.ViewModels;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Text;

namespace StoreSite;

public class Startup
{
    private const string secretKeyPath = "Jwt:SecretKey";
    private const string issuerPath = "Jwt:Issuer";
    private const string audiencePath = "Jwt:Audience";

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
            config.CreateMap<Product, Core.Models.Product>().ReverseMap();
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
        string secretKey = this.Configuration[secretKeyPath] ?? throw new KeyNotFoundException("don't find the secretKey in the json ");

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
                    ValidIssuer = Configuration[issuerPath],
                    ValidAudience = Configuration[audiencePath],
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