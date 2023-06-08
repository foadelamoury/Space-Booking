using Application.Common.Interfaces;
using Application.Features.User.Models;
using Application.Interfaces;
using MediatR;

namespace Application.Features.User.Commands.Create
{
    public class CreateUserCommand : UserDTO, IRequest<long>
    {
        public CreateUserCommand()
        { }


        public CreateUserCommand(UserDTO dto)
        {
            Name = dto.Name;
            Id = dto.Id;
            StreetId = dto.StreetId;
            CreateDate =dto.CreateDate;


        }
        public class Handler : IRequestHandler<CreateUserCommand, long>
        {
            private readonly IApplicationDbContext _context;
            private readonly IFileUploadHelper _uploadHelper;

            public Handler(IApplicationDbContext context, IFileUploadHelper uploadHelper)
            {

                _context = context;
                _uploadHelper = uploadHelper;
            }
            public async Task<long> Handle(CreateUserCommand request, CancellationToken cancellationToken)
            {
                Domain.Entities.User entity = new Domain.Entities.User
                {
                    Id = request.Id,

                    Name = request.Name,
                    StreetId = request.StreetId,
           
           


                };

                await _context.Users.AddAsync(entity);
                await _context.SaveChangesAsync(cancellationToken);


                return entity.Id;
            }

        }
    }
}

