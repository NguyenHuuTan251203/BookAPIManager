using FluentValidation;
using Repository.Infrastructure;
using Repository.UseCase.Features.Books.Commands.CreateBook;
using Repository.UseCase.Features.Books.Commands.DeleteBook;
using Repository.UseCase.Features.Books.Commands.UpdateBook;
using Repository.UseCase.Interface;
using Repository.UseCase.Features.Behaviors;
using System.Reflection;
using WEBAPI.Exceptions;
using Repository.UseCase.Features.Books.Queries.GetAllBooks;
using Repository.UseCase.Features.Books.Queries.GetById;
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
            builder.Services.AddValidatorsFromAssemblyContaining<CreateBookCommandValidator>();
            builder.Services.AddValidatorsFromAssemblyContaining<UpdateBookCommandValidator>();
            builder.Services.AddValidatorsFromAssemblyContaining<DeleteBookCommandValidator>();
            builder.Services.AddValidatorsFromAssemblyContaining<GetByIdBookQueryValidator>();


            //builder.Services.AddValidatorsFromAssemblyContaining<Program>();
            builder.Services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());



            builder.Services.AddMediatR(cfg =>
                {
                    cfg.RegisterServicesFromAssemblyContaining<CreateBookCommand>();
                    cfg.RegisterServicesFromAssemblyContaining<UpdateBookCommand>();
                    cfg.RegisterServicesFromAssemblyContaining<DeleteBookCommand>();
                    cfg.RegisterServicesFromAssemblyContaining<GetAllBooksQuery>();
                    cfg.RegisterServicesFromAssemblyContaining<GetByIdBookQuery>();

                    cfg.AddOpenBehavior(typeof(ValidatorBehavior<,>));
                });


            //Infrastructure
            builder.Services.AddSingleton<IRepositoryBookManager, InMemoryRepository>();
            builder.Services.AddSingleton<InMemoryRepository>();

            builder.Services.AddSingleton(new RepositoryMongodb(new MongodbOptions()
            {
                ConnectionString = "mongodb://localhost:27017/",
                DatabaseName = "BookManager"
            }));

            //Exception
            builder.Services.AddExceptionHandler<GlobalExceptionHandler>();
            builder.Services.AddProblemDetails();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            app.UseExceptionHandler();
            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
