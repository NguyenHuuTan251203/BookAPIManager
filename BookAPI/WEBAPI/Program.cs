using Repository.Infrastructure;
using Repository.UseCase.Interface;
using Repository.UseCase.Features.Books.Commands.CreateBook;
using Repository.UseCase.Features.Books.Commands.UpdateBook;
using Repository.UseCase.Features.Books.Commands.DeleteBook;
using FluentValidation;
namespace WEBAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllers();

            // Register validation
            //builder.Services.AddValidatorsFromAssemblyContaining<CreateBookCommandValidator>();
            //builder.Services.AddValidatorsFromAssemblyContaining<UpdateBookCommandValidator>();
            builder.Services.AddValidatorsFromAssemblyContaining<Program>();



            builder.Services.AddMediatR(cfg =>
                {
                    cfg.RegisterServicesFromAssemblyContaining<CreateBookCommand>();
                    cfg.RegisterServicesFromAssemblyContaining<UpdateBookCommand>();
                    cfg.RegisterServicesFromAssemblyContaining<DeleteBookCommand>();
                });


            //Infrastructure
            builder.Services.AddSingleton<IRepositoryBookManager, InMemoryRepository>();
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
