
using CRM.Api.Middleware;
using CRM.Business.Abstract;
using CRM.Business.Concrete;
using CRM.DAL.Abstract.DataManagement;
using CRM.DAL.Concrete.EntityFramework;
using CRM.DAL.Concrete.EntityFramework.DataManagement;

namespace CRM.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            
            var builder = WebApplication.CreateBuilder(args);

            //// Add services to the container.

            builder.Services.AddControllers().AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.PropertyNamingPolicy = null;
            });
            //// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddDbContext<CRMContext>();
            builder.Services.AddHttpContextAccessor();
            builder.Services.AddScoped<IUnitOfWork, EfUnitOfWork>();
            builder.Services.AddScoped<IGroupService, GroupManager>();
            builder.Services.AddScoped<IUserService, UserManager>();
            builder.Services.AddScoped<ICategoryService, CategoryManager>();
            builder.Services.AddScoped<IProductService, ProductManager>();

            var app = builder.Build();

            app.UseGlobalExceptionMiddleware();
            //// Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            app.UseAuthorizationMiddleware();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
