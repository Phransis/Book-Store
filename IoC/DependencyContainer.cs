using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.OpenApi.Models;
using PopePhransisBookStore.Data;
using PopePhransisBookStore.DTO;
using PopePhransisBookStore.MappingProfile;
using PopePhransisBookStore.Model;
using PopePhransisBookStore.Repository;
using Swashbuckle.AspNetCore.Filters;

namespace PopePhransisBookStore.IoC
{
    public class DependencyContainer
    {
        public static void RegisterDependencies(IServiceCollection services, IConfiguration configuration) 
        {
            services.AddTransient<IBookRepository, BookRepository>();

            services.AddAutoMapper(typeof(MappingProfile1));

            services.AddIdentityApiEndpoints<ApplicationUser>().AddEntityFrameworkStores<ApplicationDbContext>();

            services.AddSwaggerGen(options => {
                options.AddSecurityDefinition("oauth2", new Microsoft.OpenApi.Models.OpenApiSecurityScheme
                {
                    In = ParameterLocation.Header,
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey
                });
                options.OperationFilter<SecurityRequirementsOperationFilter>();
            });

            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

        }

    }
}
