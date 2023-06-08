using Application.Features.User.Models;
using Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.User.Queries.GetById
{
    public class GetUserByIdQuery : IRequest<UserDTO>
    {
        public long Id { get; set; }
    }
    public class Handler : IRequestHandler<GetUserByIdQuery, UserDTO>
    {
        private readonly IApplicationDbContext _context;
        public Handler(IApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<UserDTO> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            var country = await _context.Users.Where(x => x.Id == request.Id).Select(x => new UserDTO
            {
                Id = x.Id,
                Name = x.Name,
                SortIndex = x.SortIndex,
                Focus = x.Focus,
                Active = x.Active
            }).FirstOrDefaultAsync(cancellationToken: cancellationToken);

#pragma warning disable CS8603 // Possible null reference return.
            return country;
#pragma warning restore CS8603 // Possible null reference return.
        }
    }
}
