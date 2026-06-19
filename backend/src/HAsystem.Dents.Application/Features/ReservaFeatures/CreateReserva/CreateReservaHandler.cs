using FluentValidation;
using HAsystem.Dents.Application.Common;
using HAsystem.Dents.Application.QueryServices;
using HAsystem.Dents.Core;
using HAsystem.Dents.Domain.Aggregates.CitaAggregates;
using HAsystem.Dents.Domain.Aggregates.ReservaAggregates;

namespace HAsystem.Dents.Application.Features.ReservaFeacture.CreateReserva;

public class CreateReservaHandler
{
    private readonly IValidator<ReservaCreateRequestDto> _validator;
    private readonly IReservaRepository _reservaRepository;
    private readonly IPacienteReadService _pacienteReadService;
    private readonly ICitaRepository _citaRepository;

    public CreateReservaHandler(IValidator<ReservaCreateRequestDto> validator, IReservaRepository reservaRepository, IPacienteReadService pacienteReadService, ICitaRepository citaRepository)
    {
        _validator = validator;
        _reservaRepository = reservaRepository;
        _pacienteReadService = pacienteReadService;
        _citaRepository = citaRepository;
    }

    public async Task<Result<ReservaCreateResponseDTO>> Handle(ReservaCreateRequestDto request)
    {
        var validationResult = _validator.Validate(request);
        if (!validationResult.IsValid)
        {
            var validationErrors = validationResult.Errors.Select(codeItem => new CustomError(string.Empty, codeItem.ErrorMessage, "Validacion")).ToList();
            return Result<ReservaCreateResponseDTO>.Failure(null, validationErrors);
        }

        int idPaciente = request.IdPaciente;

        if (idPaciente == 0)
        {
            var paciente = await _pacienteReadService.GetPacienteDtoAsync(request.Dni);
            if (paciente == null)
                return Result<ReservaCreateResponseDTO>.Failure(new CustomError(string.Empty, $"El paciente con DNI {request.Dni} no está registrado. Por favor registre al paciente primero.", "Validacion"));

            idPaciente = paciente.Id;
        }

        var reserva = Reserva.Create(
            idPaciente,
            request.EstadoReserva,
            request.FechaReserva,
            request.FechaAtencion,
            request.HoraAtencion,
            request.Dni,
            request.MotivoConsulta,
            request.Observaciones
        );

        _reservaRepository.SaveReserva(reserva);
        await _reservaRepository.UnitOfWork.SaveAsync();

        // Si la reserva se crea directamente como "Confirmada", generar cita automáticamente
        if (reserva.EstadoReserva == "Confirmada")
        {
            var nuevaCita = Cita.Create(
                reserva.Id,
                reserva.IdPaciente,
                reserva.FechaAtencion,
                reserva.HoraAtencion,
                "Pendiente"
            );
            _citaRepository.Save(nuevaCita);
            await _citaRepository.UnitOfWork.SaveAsync();
        }

        var response = reserva.MapToReservaResponse();
        return Result<ReservaCreateResponseDTO>.Success(response);
    }
}
