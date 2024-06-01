﻿using CarWorkshop.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarWorkshop.Application.CarWorkshop.Commands.EditCarWorkshop
{
    public class EditCarWorkshopCommandHandler : IRequestHandler<EditCarWorkshopCommand>
    {
        private ICarWorkshopRepository _carWorkshopRepository;

        public EditCarWorkshopCommandHandler(ICarWorkshopRepository carWorkshopRepository)
        {
            _carWorkshopRepository = carWorkshopRepository;
        }

        public ICarWorkshopRepository CarWorkshopRepository { get; }

        public async Task<Unit> Handle(EditCarWorkshopCommand request, CancellationToken cancellationToken)
        {
            var carWorkshop = await _carWorkshopRepository.GetByEncodedName(request.EncodedName!);
            carWorkshop.Description = request.Description;
            carWorkshop.ContactDetails.PhoneNumber = request.PhoneNumber;
            carWorkshop.ContactDetails.Street = request.Street;
            carWorkshop.ContactDetails.City = request.City;
            carWorkshop.ContactDetails.PostalCode = request.PostalCode;

            await _carWorkshopRepository.Commit();
            return Unit.Value;
        }
    }
}
