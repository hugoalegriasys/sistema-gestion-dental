using Ngsystem.Infrastructure.Dtos;
using Refit;

namespace Ngsystem.Infrastructure.Infrastructure.Http;
public interface IReserva
{
    [Get("/Reserva/ListaReserva")]
    Task<ResultadoDTO<LisReservaResponseDto>> ListaReserva();

    [Post("/Reserva/GrabarReserva")]
    Task<ResultadoDTO<LisReservaResponseDto>> GrabarReserva([Body] SaveReservaRequestDto oreg);

    [Put("/Reserva/UpdateReserva")]
    Task<ResultadoDTO<LisReservaResponseDto>> UpdateReserva([Body] SaveReservaRequestDto oreg);
}

