using Ngsystem.Infrastructure.Dtos;
using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ngsystem.Infrastructure.Infrastructure.Http;
    public interface IReserva
    {
        [Get("/Reserva/ListaReserva")]
        Task<ResultadoDTO<LisReservaResponseDto>> ListaReserva();

        [Post("/Reserva/GrabarReserva")]
        Task<ResultadoDTO<LisReservaResponseDto>> GrabarReserva(LisReservaResponseDto oreg);
        [Put("/Reserva/UpdateReserva")]
        Task<ResultadoDTO<LisReservaResponseDto>> UpdateReserva(LisReservaResponseDto oreg);
    }

