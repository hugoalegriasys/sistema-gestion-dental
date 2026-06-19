using Microsoft.AspNetCore.Components;
using Ngsystem.Infrastructure.Dtos;
using Ngsystem.Infrastructure.Infrastructure.Http;
using MudBlazor;

namespace Ngsystem.FrontDentis.Pages.Citas;

public class CitaBase : ComponentBase
{
    [Inject] ICita? _citaServicio { get; set; }
    [Inject] IDialogService DialogService { get; set; }
    [Inject] ISnackbar? _snackBar { get; set; }

    public string searchString1 = "";
    public CitaResponseDto? selectedItem1 = null;
    public bool _loading = false;
    public bool estadoLoad = false;

    public IEnumerable<CitaResponseDto>? listaCitaDto { get; set; }

    protected override async Task OnInitializedAsync()
    {
        await CargarCitas();
    }

    public async Task CargarCitas()
    {
        estadoLoad = true;
        var response = await _citaServicio.ListaCita();
        if (response.Status)
        {
            listaCitaDto = response.Lista;
        }
        estadoLoad = false;
    }

    public async Task AbrirModalAtencion(CitaResponseDto cita)
    {
        var parameters = new DialogParameters { ["IdCita"] = cita.IdCita };
        var dialog = await DialogService.ShowAsync<ModalAtencionCita>("Registrar Atención", parameters);
        var result = await dialog.Result;
        if (!result.Canceled)
        {
            await CargarCitas();
        }
    }

    public bool FilterFunc1(CitaResponseDto cita) => FilterFunc(cita, searchString1);

    public bool FilterFunc(CitaResponseDto c, string searchString)
    {
        if (string.IsNullOrWhiteSpace(searchString))
            return true;

        var s = searchString.ToLowerInvariant();

        return (c.DniPaciente?.ToLowerInvariant().Contains(s) ?? false)
            || (c.NombresPaciente?.ToLowerInvariant().Contains(s) ?? false)
            || (c.ApellidosPaciente?.ToLowerInvariant().Contains(s) ?? false)
            || (c.EstadoCita?.ToLowerInvariant().Contains(s) ?? false);
    }

    public Color GetEstadoColor(string? estado) => estado switch
    {
        "Pendiente"  => Color.Warning,
        "En Atención" => Color.Info,
        "Atendida"   => Color.Success,
        "No Asistió" => Color.Error,
        _            => Color.Default
    };

    public async Task CambiarEstado(CitaResponseDto cita, string nuevoEstado)
    {
        if (nuevoEstado == "Atendida")
        {
            await AbrirModalAtencion(cita);
            return;
        }

        var request = new UpdateCitaRequestDto
        {
            IdCita = cita.IdCita,
            EstadoCita = nuevoEstado,
            Diagnostico = cita.Diagnostico,
            TratamientoRealizado = cita.TratamientoRealizado,
            Observaciones = cita.Observaciones
        };

        try
        {
            var response = await _citaServicio.UpdateCita(request);
            if (response.Status)
            {
                cita.EstadoCita = nuevoEstado;
                _snackBar?.Add($"Estado actualizado a {nuevoEstado}", Severity.Success);
            }
            else
            {
                _snackBar?.Add("Error al actualizar el estado", Severity.Error);
            }
        }
        catch
        {
            _snackBar?.Add("Error de conexión al actualizar el estado", Severity.Error);
        }
    }
}
