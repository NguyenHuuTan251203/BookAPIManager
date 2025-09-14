using Repository.UseCase.Features.Books.Queries.GetAllBooks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.UseCase.Features.Books.Queries.GetAllBookQueryHandle
{
    public class GetAllBookQueryHandle(IRepositoryBookManager repositoryBookManager) : IRequestHandler<GetAllBooksQuery, List<Book>>
    {
        public async Task<List<Book>> Handle(GetAllBooksQuery request, CancellationToken cancellationToken)
        {
            return await repositoryBookManager.GetAllBook();
        }
    }
}
