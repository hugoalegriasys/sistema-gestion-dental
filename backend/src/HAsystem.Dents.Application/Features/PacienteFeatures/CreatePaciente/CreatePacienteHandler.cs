using FluentValidation;
using HAsystem.Dents.Application.Common;
using HAsystem.Dents.Application.QueryServices;
using HAsystem.Dents.Core;
using HAsystem.Dents.Domain.Aggregates.PacienteAggregates;

namespace HAsystem.Dents.Application.Features.PacienteFeatures.CreatePaciente;

public class CreatePacienteHandler
{
    private readonly IValidator<PacienteCreateRequestDto> _validator;
    private readonly IPacienteRepository _pacienteRepository;
    public CreatePacienteHandler(IValidator<PacienteCreateRequestDto> validator, IPacienteRepository pacienteRepository)
    {
        _validator = validator;
        _pacienteRepository = pacienteRepository;
    }
    public async Task<Result<PacienteCreateResponseDTO>> Handle(PacienteCreateRequestDto request)
    {
        //validación de aplicación
        var validationResult = _validator.Validate(request);
        if (!validationResult.IsValid)
        {
            var validationErrors = validationResult.Errors.Select(codeItem => new CustomError(string.Empty, codeItem.ErrorMessage, "Validacion")).ToList();
            return Result<PacienteCreateResponseDTO>.Failure(null,validationErrors);
        }

        var paciente = request.MapToPaciente();
        _pacienteRepository.SavePaciente(paciente);
        await _pacienteRepository.UnitOfWork.SaveAsync();
        var response = paciente.MapToPacienteResponse();
        return Result<PacienteCreateResponseDTO>.Success(response);
    }
}
