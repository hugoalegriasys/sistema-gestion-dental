namespace HAsystem.Dents.Application.Features.CitaFeatures;

public interface ICitaReadService
{
    Task<List<CitaResponseDto>> ListaCita();
}
