using FluentValidation;
using HAsystem.Dents.Application.Common;
using HAsystem.Dents.Application.QueryServices;
using HAsystem.Dents.Core;

using HAsystem.Dents.Domain.Aggregates.PacienteAggregates;

namespace HAsystem.Dents.Application.Features.PacienteFeatures.ListPacientes;

public class ListPacienteHandler
{
    private readonly IPacienteReadService _pacienteService;
    public ListPacienteHandler(IPacienteReadService pacienteService)
    {
        _pacienteService = pacienteService;
    }
    public async Task<Result<IEnumerable<LisPacienteResponseDto>>> Handle()
    {
        //validación de aplicación


        var response = await _pacienteService.ListPacienteDtoAsync();

        return Result<IEnumerable<LisPacienteResponseDto>>.Success(response);

    }
}
