
using FluentValidation;

namespace HAsystem.Dents.Application.Features.PacienteFeatures.DeletePacientes
{
    public class DeletePacienteValidation : AbstractValidator<PacienteDeleteRequestDto>
    {
        public DeletePacienteValidation()
    {
        RuleFor(x => x.Id)
            .NotEmpty();

    }
}
}
