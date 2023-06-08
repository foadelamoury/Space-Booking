using Application.Features.Country.Models;
using Application.Interfaces;
using MediatR;

namespace Application.Features.Country.Commands.Update
{
    public class UpdateCountryCommand : CountryDTO, IRequest<long>
    {
        public UpdateCountryCommand()
        { }


        public UpdateCountryCommand(CountryDTO dto)
        {
            Id = dto.Id;

            Name = dto.Name; 



        }
        public class Handler : IRequestHandler<UpdateCountryCommand, long>
        {
            private readonly IApplicationDbContext _context;
            public Handler(IApplicationDbContext context)
            {

                _context = context;
            }
            public async Task<long> Handle(UpdateCountryCommand request, CancellationToken cancellationToken)
            {
                Domain.Entities.Country entity = new Domain.Entities.Country
                {
                    Name = request.Name,
                    Id = request.Id,
                    ModifyDate = DateTime.Now


                };


                _context.Countries.Update(entity);
                await _context.SaveChangesAsync(cancellationToken);




                return entity.Id;
            }

        }
    }

}