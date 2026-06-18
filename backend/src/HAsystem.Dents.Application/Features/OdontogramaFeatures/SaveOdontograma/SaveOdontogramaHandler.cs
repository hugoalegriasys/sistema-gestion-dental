using HAsystem.Dents.Core;
using HAsystem.Dents.Domain.Aggregates.OdontogramaAggregates;

namespace HAsystem.Dents.Application.Features.OdontogramaFeatures.SaveOdontograma;

public class SaveOdontogramaHandler
{
    private readonly IOdontogramaRepository _odontogramaRepository;

    public SaveOdontogramaHandler(IOdontogramaRepository odontogramaRepository)
    {
        _odontogramaRepository = odontogramaRepository;
    }

    public async Task<Result<SaveOdontogramaResponseDto>> Handle(SaveOdontogramaRequestDto request)
    {
        var existente = await _odontogramaRepository.GetByPacienteAndDienteAsync(
            request.IdPaciente, request.NumeroDiente);

        if (existente is not null)
        {
            existente.Update(request.NumeroDiente, request.EstadoDiente, request.Observaciones);
            _odontogramaRepository.Update(existente);
        }
        else
        {
            var nuevo = Odontograma.Create(
                request.IdPaciente,
                request.NumeroDiente,
                request.EstadoDiente,
                request.Observaciones
            );
            _odontogramaRepository.Save(nuevo);
        }

        await _odontogramaRepository.UnitOfWork.SaveAsync();

        return Result<SaveOdontogramaResponseDto>.Success(
            new SaveOdontogramaResponseDto("Odontograma guardado correctamente"));
    }
}
