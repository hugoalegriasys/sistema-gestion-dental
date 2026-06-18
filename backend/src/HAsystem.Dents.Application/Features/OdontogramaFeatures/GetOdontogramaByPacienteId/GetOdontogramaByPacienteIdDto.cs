namespace HAsystem.Dents.Application.Features.OdontogramaFeatures.GetOdontogramaByPacienteId;

public record OdontogramaItemDto(
    int Id,
    int IdPaciente,
    int NumeroDiente,
    string EstadoDiente,
    string? Observaciones,
    string Fecha
);
