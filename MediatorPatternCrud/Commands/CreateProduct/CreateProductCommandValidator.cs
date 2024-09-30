using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediatorPatternCrud.Commands.CreateProduct
{
	public class CreateProductCommandValidator : AbstractValidator<CreateProductCommand>
	{
		public CreateProductCommandValidator()
		{
			
			RuleFor(x => x.Name).NotEmpty().WithMessage("Name can't be empty.");
			RuleFor(x => x.Price).GreaterThan(0).WithMessage("Price must be greater than 0.");
		}
	
	}
}
