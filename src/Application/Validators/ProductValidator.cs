using FluentValidation;
using Product_Management.src.Application.DTOs.Product;

namespace Product_Management.src.Application.Validators
{
    public class ProductValidator : AbstractValidator<CreateProductDto>
    {
        public ProductValidator()
        {
            RuleFor(x => x.ProductName)
                .NotEmpty()
                .MaximumLength(255);
        }
    }
}
