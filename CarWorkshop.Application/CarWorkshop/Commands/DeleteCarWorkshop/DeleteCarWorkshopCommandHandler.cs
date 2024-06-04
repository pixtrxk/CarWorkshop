using CarWorkshop.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarWorkshop.Application.CarWorkshop.Commands.DeleteCarWorkshop
{
    public class DeleteCarWorkshopCommandHandler : IRequestHandler<DeleteCarWorkshopCommand>
    {
        private readonly ICarWorkshopRepository _carWorkshopRepository;

        public DeleteCarWorkshopCommandHandler(ICarWorkshopRepository carWorkshopRepository)
        {
            _carWorkshopRepository = carWorkshopRepository;
        }
        public async Task<Unit> Handle(DeleteCarWorkshopCommand request, CancellationToken cancellationToken)
        {
            var carWorkshop = await _carWorkshopRepository.GetByEncodedName(request.EncodedName!);
            await _carWorkshopRepository.Delete(carWorkshop);
            return Unit.Value;
        }
    }
}
