using Repository.Entity;
namespace Repository.UseCase.Validation
{
    public class ValidDataBook : IValidate
    {
        public bool CheckDataBook(Book book) => !string.IsNullOrWhiteSpace(book.Title) && book.Price > 0;
    }
}
