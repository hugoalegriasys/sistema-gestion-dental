using Ngsystem.Infrastructure.Dtos;
using Refit;

namespace Ngsystem.Infrastructure.Infrastructure.Http;

public interface ICita
{
    [Get("/Cita/ListaCita")]
    Task<ResultadoDTO<CitaResponseDto>> ListaCita();

    [Put("/Cita/UpdateCita")]
    Task<ResultadoDTO<string>> UpdateCita([Body] UpdateCitaRequestDto request);
}
