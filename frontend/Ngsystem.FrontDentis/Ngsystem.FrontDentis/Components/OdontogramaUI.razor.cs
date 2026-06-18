using Microsoft.AspNetCore.Components;
using MudBlazor;
using Ngsystem.Infrastructure.Dtos;
using Ngsystem.Infrastructure.Infrastructure.Http;

namespace Ngsystem.FrontDentis.Components;

public class OdontogramaUIBase : ComponentBase
{
    [Inject] protected IOdontograma? OdontogramaService { get; set; }
    [Inject] protected IDialogService? DialogService { get; set; }
    [Inject] protected ISnackbar? Snackbar { get; set; }

    [Parameter] public int IdPaciente { get; set; }

    protected bool estadoLoad = true;
    protected int? dienteSeleccionado;

    protected readonly Dictionary<int, string> Estados = new();
    protected readonly Dictionary<int, string> Observaciones = new();
    protected readonly Dictionary<int, (int Orden, int Fila, int Columna)> Layout = new();

    protected static readonly int[] TopArch = { 18, 17, 16, 15, 14, 13, 12, 11, 21, 22, 23, 24, 25, 26, 27, 28 };
    protected static readonly int[] BottomArch = { 48, 47, 46, 45, 44, 43, 42, 41, 31, 32, 33, 34, 35, 36, 37, 38 };

    protected override void OnInitialized()
    {
        var idx = 0;
        foreach (var n in TopArch) Layout[n] = (idx++, 0, idx - 1);
        foreach (var n in BottomArch) Layout[n] = (idx++, 1, idx - 1 - TopArch.Length);
    }

    protected override async Task OnInitializedAsync()
    {
        await CargarOdontograma();
    }

    protected async Task CargarOdontograma()
    {
        estadoLoad = true;
        Estados.Clear();
        Observaciones.Clear();

        var response = await OdontogramaService!.ListaOdontograma(IdPaciente);
        if (response is { Status: true, Lista: not null })
        {
            foreach (var item in response.Lista)
            {
                Estados[item.NumeroDiente] = item.EstadoDiente ?? "Sano";
                Observaciones[item.NumeroDiente] = item.Observaciones ?? "";
            }
        }

        estadoLoad = false;
    }

    protected async Task OnDienteSeleccionado(int numeroDiente)
    {
        dienteSeleccionado = numeroDiente;
        var estadoActual = Estados.GetValueOrDefault(numeroDiente, "Sano");
        var observacionesActual = Observaciones.GetValueOrDefault(numeroDiente, "");

        var parameters = new DialogParameters
        {
            ["NumeroDiente"] = numeroDiente,
            ["EstadoActual"] = estadoActual,
            ["ObservacionesActual"] = observacionesActual
        };
        var options = new DialogOptions
        {
            MaxWidth = MaxWidth.Small,
            FullWidth = true,
            CloseButton = true
        };

        var dialog = DialogService?.Show<OdontogramaDialog>(
            $"Editar Diente {numeroDiente}",
            parameters,
            options
        );

        if (dialog is null) return;
        var result = await dialog.Result;

        if (result.Canceled) return;

        if (result.Data is OdontogramaDialogResult data)
        {
            await GuardarEstado(numeroDiente, data.NuevoEstado, data.NuevasObservaciones);
        }
    }

    protected async Task GuardarEstado(int numeroDiente, string nuevoEstado, string nuevasObservaciones)
    {
        var request = new SaveOdontogramaRequestDto
        {
            IdPaciente = IdPaciente,
            NumeroDiente = numeroDiente,
            EstadoDiente = nuevoEstado,
            Observaciones = nuevasObservaciones
        };

        var response = await OdontogramaService!.GuardarOdontograma(request);

        if (response is { Status: true })
        {
            Snackbar?.Add(
                $"Diente {numeroDiente} → {nuevoEstado}",
                Severity.Success,
                config => config.VisibleStateDuration = 2000
            );
            await CargarOdontograma();
            StateHasChanged();
        }
        else
        {
            Snackbar?.Add(
                "Error al guardar el estado del diente",
                Severity.Error,
                config => config.VisibleStateDuration = 3000
            );
        }
    }

    protected static string ClaseEstado(string estado)
    {
        return $"diente-{(estado ?? "Sano").ToLowerInvariant()}";
    }
}
