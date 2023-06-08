using Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.User.Commands.Delete
{
    public class DeleteUserCommand : IRequest<int>
    {
        public int Id { get; set; }
    }
    public class Handler : IRequestHandler<DeleteUserCommand, int>
    {
        private readonly IApplicationDbContext _context;
        public Handler(IApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<int> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
           
                int result = await _context.SaveChangesAsync(cancellationToken);

            return result;


        }
    }
}
