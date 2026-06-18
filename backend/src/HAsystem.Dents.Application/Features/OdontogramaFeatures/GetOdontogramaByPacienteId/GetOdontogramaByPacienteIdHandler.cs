using HAsystem.Dents.Core;
using HAsystem.Dents.Domain.Aggregates.OdontogramaAggregates;

namespace HAsystem.Dents.Application.Features.OdontogramaFeatures.GetOdontogramaByPacienteId;

public class GetOdontogramaByPacienteIdHandler
{
    private readonly IOdontogramaRepository _odontogramaRepository;

    public GetOdontogramaByPacienteIdHandler(IOdontogramaRepository odontogramaRepository)
    {
        _odontogramaRepository = odontogramaRepository;
    }

    public async Task<Result<IEnumerable<OdontogramaItemDto>>> Handle(int idPaciente)
    {
        var registros = await _odontogramaRepository.ListByPacienteIdAsync(idPaciente);

        var dto = registros.Select(r => new OdontogramaItemDto(
            r.Id,
            r.IdPaciente,
            r.NumeroDiente,
            r.EstadoDiente,
            r.Observaciones,
            r.Fecha.ToString("yyyy-MM-dd")
        ));

        return Result<IEnumerable<OdontogramaItemDto>>.Success(dto);
    }
}
