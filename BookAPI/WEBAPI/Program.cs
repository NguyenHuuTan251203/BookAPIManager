using Repository.Infrastructure;
using Repository.UseCase;
namespace WEBAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            builder.Services.AddSingleton<IRepositoryBookManager,InMemoryRepository>();
            builder.Services.AddSingleton<InMemoryRepository>();

            builder.Services.AddSingleton(new RepositoryMongodb(new MongodbOptions()
            {
                ConnectionString = "mongodb://localhost:27017/",
                DatabaseName = "BookManager"
            }));

            var app = builder.Build();

            // Configure the HTTP request pipeline.

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
