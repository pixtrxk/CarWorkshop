using CarWorkshop.Domain.Interfaces;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarWorkshop.Application.CarWorkshop
{
	public class CarWorkshopDtoValidator:AbstractValidator<CarWorkshopDto>
	{
        public CarWorkshopDtoValidator(ICarWorkshopRepository repository)
        {
            RuleFor(c => c.Name)
                .NotEmpty()
                .MinimumLength(5)
                .MaximumLength(20)
                .Custom((value, context) =>
                {
                    var existingCarWorkshop = repository.GetByName(value).Result;
                    if (existingCarWorkshop != null)
                    {
                        context.AddFailure($"{value} is not unique");
                    }
                });           

            RuleFor(c => c.Description)
                .NotEmpty();
            RuleFor(c => c.PhoneNumber)
                .MinimumLength(8)
                .MaximumLength(12);
        }
    }
}
