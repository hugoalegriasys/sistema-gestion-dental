using HAsystem.Dents.Application.Features.CitaFeatures;
using HAsystem.Dents.Core;

namespace HAsystem.Dents.Application.Features.CitaFeatures.ListCita;

public class ListCitaHandler
{
    private readonly ICitaReadService _citaReadService;

    public ListCitaHandler(ICitaReadService citaReadService)
    {
        _citaReadService = citaReadService;
    }

    public async Task<Result<List<CitaResponseDto>>> Handle()
    {
        var response = await _citaReadService.ListaCita();
        return Result<List<CitaResponseDto>>.Success(response);
    }
}
