using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using HAsystem.Dents.Application.Common;
using HAsystem.Dents.Application.Features.PacienteFeatures.DeletePacientes;
using HAsystem.Dents.Application.Features.PacienteFeatures.UpdatePacientes;
using HAsystem.Dents.Application.QueryServices;
using HAsystem.Dents.Core;
using HAsystem.Dents.Domain.Aggregates.PacienteAggregates;

namespace HAsystem.Dents.Application.Features.PacienteFeatures.DeletePacientes
{
    public class DeletePacienteHandler
    {
        private readonly IValidator<PacienteDeleteRequestDto> _validator;
        private readonly IPacienteRepository _pacienteRepository;
        private readonly IPacienteReadService _pacienteReadService;
        public DeletePacienteHandler(IValidator<PacienteDeleteRequestDto> validator, IPacienteRepository pacienteRepository, IPacienteReadService pacienteReadService)
        {
            _validator = validator;
            _pacienteRepository = pacienteRepository;
            _pacienteReadService = pacienteReadService;
        }

        public async Task<Result<PacienteDeleteResponseDTO>> Handle(PacienteDeleteRequestDto request)
        {
            // Validación asíncrona
            var validationResult = await _validator.ValidateAsync(request);
            if (!validationResult.IsValid)
            {
                var validationErrors = validationResult.Errors
                    .Select(err => new CustomError(string.Empty, err.ErrorMessage, "Validación")).ToList();
                return Result<PacienteDeleteResponseDTO>.Failure(null, validationErrors);
            }

            // Buscar paciente
            var paciente = await _pacienteReadService.GetIdPacienteDtoAsync(request.Id);
            if (paciente == null)
            {
                return Result<PacienteDeleteResponseDTO>.Failure(new CustomError("Paciente", "No encontrado", "Negocio"), null);
            }
            // Actualizar propiedades
            paciente.MapToDeletePaciente(request);
            // Guardar cambios
            _pacienteRepository.UpdatePaciente(paciente);
            await _pacienteRepository.UnitOfWork.SaveAsync();
            // Mapear y responder
            var response = paciente.MapToDeletePacienteResponse();
            return Result<PacienteDeleteResponseDTO>.Success(response);
        }
    }
}
