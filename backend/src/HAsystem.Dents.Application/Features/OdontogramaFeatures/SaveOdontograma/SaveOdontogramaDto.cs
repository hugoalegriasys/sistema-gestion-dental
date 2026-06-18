namespace HAsystem.Dents.Application.Features.OdontogramaFeatures.SaveOdontograma;

public record SaveOdontogramaRequestDto(
    int IdPaciente,
    int NumeroDiente,
    string EstadoDiente,
    string? Observaciones
);

public record SaveOdontogramaResponseDto(string mensaje);
