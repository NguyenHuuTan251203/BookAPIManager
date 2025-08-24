using Repository.Entity;
namespace Repository.UseCase.Validation
{
    public class ValidDataBook : IValidate
    {
        public bool CheckDataBook(Book book) => !string.IsNullOrWhiteSpace(book.Title) && book.Price > 0;
            //if(book.Title == null) return false;
            //if(book.Price < 0) return false;
            //return true;
        
    }
}
