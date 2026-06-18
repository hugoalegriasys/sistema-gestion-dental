using FluentValidation;

namespace HAsystem.Dents.Application.Features.ReservaFeacture.GetReserva;
public class GetReservaValidation : AbstractValidator<ReservaRequestDto>
{
    public GetReservaValidation()
    {
        RuleFor(x => x.dni)
            .NotEmpty()
            .Length(8)
            .Matches(@"^\d{8}$");

    }
}
