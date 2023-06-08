using Application.Features.User.Models;
using Application.Interfaces;
using MediatR;

namespace Application.Features.User.Commands.Update
{
    public class UpdateUserCommand : UserDTO, IRequest<long>
    {
        public UpdateUserCommand()
        { }


        public UpdateUserCommand(UserDTO dto)
        {
            Name = dto.Name;
            Id = dto.Id;

        }
        public class Handler : IRequestHandler<UpdateUserCommand, long>
        {
            private readonly IApplicationDbContext _context;
            public Handler(IApplicationDbContext context)
            {

                _context = context;
            }
            public async Task<long> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
            {
                Domain.Entities.User entity = new Domain.Entities.User
                {
                    Id = request.Id,

                    Name = request.Name,

                };


                await _context.Users.AddAsync(entity);
                await _context.SaveChangesAsync(cancellationToken);




                return entity.Id;
            }

        }
    }
}