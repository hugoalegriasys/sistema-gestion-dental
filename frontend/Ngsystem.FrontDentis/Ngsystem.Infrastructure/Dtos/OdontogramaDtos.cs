namespace Ngsystem.Infrastructure.Dtos;

public class OdontogramaItemDto
{
    public int Id { get; set; }
    public int IdPaciente { get; set; }
    public int NumeroDiente { get; set; }
    public string? EstadoDiente { get; set; }
    public string? Observaciones { get; set; }
    public string? Fecha { get; set; }
}

public class SaveOdontogramaRequestDto
{
    public int IdPaciente { get; set; }
    public int NumeroDiente { get; set; }
    public string? EstadoDiente { get; set; }
    public string? Observaciones { get; set; }
}

public class SaveOdontogramaResponseDto
{
    public string? Mensaje { get; set; }
}
