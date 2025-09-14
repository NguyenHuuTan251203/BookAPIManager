using Repository.UseCase.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.UseCase.Features.Books.Commands.DeleteBook
{
    public class DeleteBoookCommandHandle : IRequestHandler<DeleteBookCommand, Unit>
    {
        private readonly IRepositoryBookManager _repositoryBookManager;

        public DeleteBoookCommandHandle(IRepositoryBookManager repositoryBookManager) {
            _repositoryBookManager = repositoryBookManager;
        }
        public async Task<Unit> Handle(DeleteBookCommand request, CancellationToken cancellationToken)
        {
            await _repositoryBookManager.DeleteBook(request.Id);
            return Unit.Value;
        }
    }
}
