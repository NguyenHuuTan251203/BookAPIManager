using Repository.Entity;

namespace Repository.UseCase.Validation
{
    public interface IValidate
    {
         bool CheckDataBook(Book book);
 
    }
}
