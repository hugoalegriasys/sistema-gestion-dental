
using FluentValidation;

namespace HAsystem.Dents.Application.Features.ReservaFeacture.DeleteReserva
{
    public class DeleteReservaValidation : AbstractValidator<ReservaDeleteRequestDto>
    {
        public DeleteReservaValidation()
        {
            RuleFor(x => x.Id)
                .NotEmpty();

        }
    }
}
