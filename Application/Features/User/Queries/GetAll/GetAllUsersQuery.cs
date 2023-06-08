using Application.Features.User.Models;
using Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.User.Queries.GetAll
{
    public class GetAllUsersQuery : IRequest<IEnumerable<UserDTO>>
    {
        public class Handler : IRequestHandler<GetAllUsersQuery, IEnumerable<UserDTO>>
        {

            private readonly IApplicationDbContext _context;
            public Handler(IApplicationDbContext context)
            {
                _context = context;
            }
            public async Task<IEnumerable<UserDTO>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
            {
                var students = await _context.Users.Select(x =>
                      new UserDTO
                      {
                          Id = x.Id,
                          Name = x.Name,
                          SortIndex = x.SortIndex,
                          Focus = x.Focus,
                          Active = x.Active

                      }
                  ).ToListAsync();

                return students;
            }
        }
    }

}