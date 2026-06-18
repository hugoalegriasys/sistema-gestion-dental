using Ngsystem.Infrastructure.Dtos;
using Refit;

namespace Ngsystem.Infrastructure.Infrastructure.Http;

public interface IOdontograma
{
    [Get("/Odontograma/PorPaciente/{idPaciente}")]
    Task<ResultadoDTO<OdontogramaItemDto>> ListaOdontograma(int idPaciente);

    [Post("/Odontograma/Guardar")]
    Task<ResultadoDTO<SaveOdontogramaResponseDto>> GuardarOdontograma(SaveOdontogramaRequestDto request);
}
