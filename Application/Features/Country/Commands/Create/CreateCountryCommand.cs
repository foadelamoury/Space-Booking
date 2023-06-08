using Application.Features.Country.Models;
using Application.Interfaces;
using MediatR;

namespace Application.Features.Country.Commands.Create
{
    public class CreateCountryCommand : CountryDTO, IRequest<long>
    {
        public CreateCountryCommand()
        { }


        public CreateCountryCommand(CountryDTO dto)
        {
            Name = dto.Name;
            Id = dto.Id;
            ParentId = dto.ParentId;

        }
        public class Handler : IRequestHandler<CreateCountryCommand, long>
        {
            private readonly IApplicationDbContext _context;
            public Handler(IApplicationDbContext context)
            {

                _context = context;
            }
            public async Task<long> Handle(CreateCountryCommand request, CancellationToken cancellationToken)
            {
                Domain.Entities.Country entity;

                if (request.ParentId == 0)
                {
                    entity = new Domain.Entities.Country
                    {

                        Id = request.Id,
                        Name = request.Name,
                        ParentId = null,
                        CreateDate = DateTime.Now


                    };
                    await _context.Countries.AddAsync(entity);
                    await _context.SaveChangesAsync(cancellationToken);

                    return entity.Id;


                }
                else if (request.ParentId >0)
                {

                    entity = new Domain.Entities.Country
                    {

                        Id = request.Id,
                        Name = request.Name,
                        ParentId = request.ParentId


                    };
                    await _context.Countries.AddAsync(entity);
                    await _context.SaveChangesAsync(cancellationToken);

                    return entity.Id;


                }

                return -1;




            }

        }
    }
}

