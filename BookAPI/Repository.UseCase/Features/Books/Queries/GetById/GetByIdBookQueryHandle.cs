using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.UseCase.Features.Books.Queries.GetById
{
    public class GetByIdBookQueryHandle(IRepositoryBookManager repositoryBookManager) : IRequestHandler<GetByIdBookQuery, Book>
    {
        public async Task<Book> Handle(GetByIdBookQuery request, CancellationToken cancellationToken)
        {
            var rs = await repositoryBookManager.GetBookById(request.Id);
            if (rs == null)
                throw new Exception("NOT FOUND");
            return rs;
        }
    }
}
