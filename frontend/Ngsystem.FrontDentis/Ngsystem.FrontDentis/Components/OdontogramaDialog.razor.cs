using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace Ngsystem.FrontDentis.Components;

public class OdontogramaDialogBase : ComponentBase
{
    [CascadingParameter] protected MudDialogInstance? MudDialog { get; set; }

    [Parameter] public int NumeroDiente { get; set; }
    [Parameter] public string? EstadoActual { get; set; }
    [Parameter] public string? ObservacionesActual { get; set; }

    protected string? nuevoEstado;
    protected string? nuevasObservaciones;

    protected static readonly string[] EstadosValidos = { "Sano", "Caries", "Tratado", "Extraído", "Ausente", "Endodoncia" };

    protected override void OnInitialized()
    {
        nuevoEstado = EstadoActual ?? "Sano";
        nuevasObservaciones = ObservacionesActual ?? "";
    }

    protected void Cancelar()
    {
        MudDialog?.Cancel();
    }

    protected void Guardar()
    {
        var resultado = new OdontogramaDialogResult
        {
            NuevoEstado = nuevoEstado ?? "Sano",
            NuevasObservaciones = nuevasObservaciones ?? ""
        };
        MudDialog?.Close(DialogResult.Ok(resultado));
    }
}

public class OdontogramaDialogResult
{
    public string NuevoEstado { get; set; } = "Sano";
    public string NuevasObservaciones { get; set; } = "";
}
