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
    public string horaFormateada = string.Empty;
    public string horaAtencion = string.Empty;
    //string horaFormateada = hora.ToString(@"hh\:mm\:ss");
    protected override void OnInitialized()
    {
        if (objReserva.FechaReserva != default)     
            fechaReserva = objReserva.FechaReserva;

        if (objReserva.FechaAtencion != default)
            fechaAtencion = objReserva.FechaAtencion;

        if (objReserva.HoraAtencion != default)
            horaFormateada = objReserva.HoraAtencion;
            horaAtencion = horaFormateada.Split('.')[0]; 
    }

    public void Cancel() => MudDialog.Cancel();

    public async Task MostrarConfirmacion()
    {
        // Validaciones simples
        if (string.IsNullOrWhiteSpace(objReserva.Dni) || string.IsNullOrWhiteSpace(objReserva.EstadoReserva))
            return;

        objReserva.FechaReserva = fechaReserva;
        objReserva.FechaAtencion = fechaAtencion;
        objReserva.HoraAtencion = horaAtencion;

        var confirmDialog = _dialogServicio.Show<ModalDialog>("Confirmar", new DialogParameters
        {
            { "Message", "¿Deseas guardar esta reserva?" }
        }, new DialogOptions { MaxWidth = MaxWidth.Small });

        var result = await confirmDialog.Result;

        if (!result.Canceled)
        {
            await Guardar();
        }
    }

    public async Task Guardar()
    {
        bool exito = false;
        string mensaje = "";

        if (objReserva.IdReserva == 0)
        {
            var response = await _reservaServicio.GrabarReserva(objReserva);
            exito = response.Status;
            mensaje = "Reserva registrada correctamente";
        }
        else
        {
            var response = await _reservaServicio.UpdateReserva(objReserva);
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
