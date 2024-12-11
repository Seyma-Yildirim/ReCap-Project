using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Concrete.Cars;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class CarImageValidation:AbstractValidator<CarImage>
    {
        public CarImageValidation()
        {
            RuleFor(p => p.CarId).LessThan(5);
        }
    }
}
