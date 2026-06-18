using Microsoft.AspNetCore.Components;
using MudBlazor;
using Ngsystem.FrontDentis.Components;
using Ngsystem.Infrastructure.Dtos;
using Ngsystem.Infrastructure.Infrastructure.Http;

namespace Ngsystem.FrontDentis.Pages.Reserva;

public class ModalReservaBase : ComponentBase
{
    [Parameter] public LisReservaResponseDto objReserva { get; set; } = new LisReservaResponseDto();

    [Inject] IReserva _reservaServicio { get; set; }
    [Inject] ISnackbar _snackBar { get; set; }
    [Inject] IDialogService _dialogServicio { get; set; }
    [CascadingParameter] MudDialogInstance MudDialog { get; set; }

    public DateTime fechaReserva = DateTime.Today;
    public DateTime fechaAtencion = DateTime.Today;
    public TimeSpan? horaAtencion = null;

    protected override void OnInitialized()
    {
        if (objReserva.FechaReserva != default)
            fechaReserva = objReserva.FechaReserva;

        if (objReserva.FechaAtencion != default)
            fechaAtencion = objReserva.FechaAtencion;

        if (!string.IsNullOrWhiteSpace(objReserva.HoraAtencion))
        {
            var clean = objReserva.HoraAtencion.Split('.')[0];
            if (TimeSpan.TryParse(clean, out var ts))
                horaAtencion = ts;
        }
    }

    public void Cancel() => MudDialog.Cancel();

    public async Task MostrarConfirmacion()
    {
        if (string.IsNullOrWhiteSpace(objReserva.Dni) || string.IsNullOrWhiteSpace(objReserva.EstadoReserva))
            return;

        var confirmDialog = _dialogServicio.Show<ModalDialog>("Confirmar", new DialogParameters
        {
            { "Message", "¿Deseas guardar esta reserva?" }
        }, new DialogOptions { MaxWidth = MaxWidth.Small });

        var result = await confirmDialog.Result;

        if (!result.Canceled)
            await Guardar();
    }

    public async Task Guardar()
    {
        bool exito;
        string mensaje;

        var request = new SaveReservaRequestDto
        {
            IdPaciente = objReserva.IdPaciente > 0 ? objReserva.IdPaciente : 0,
            EstadoReserva = objReserva.EstadoReserva ?? string.Empty,
            FechaReserva = fechaReserva.ToString("dd/MM/yyyy"),
            FechaAtencion = fechaAtencion.ToString("dd/MM/yyyy"),
            HoraAtencion = horaAtencion?.ToString(@"hh\:mm") ?? string.Empty,
            MotivoConsulta = objReserva.MotivoConsulta ?? string.Empty,
            Observaciones = objReserva.Observaciones,
            Dni = objReserva.Dni
        };

        if (objReserva.IdReserva == 0)
        {
            var response = await _reservaServicio.GrabarReserva(request);
            exito = response.Status;
            mensaje = "Reserva registrada correctamente";
        }
        else
        {
            var response = await _reservaServicio.UpdateReserva(request);
            exito = response.Status;
            mensaje = "Reserva actualizada correctamente";
        }

        if (exito)
        {
            _snackBar.Add(mensaje, Severity.Success);
            MudDialog.Close(DialogResult.Ok(true));
        }
        else
        {
            _snackBar.Add("Hubo un error al guardar la reserva", Severity.Error);
        }
    }
}
