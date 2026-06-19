using CurrieTechnologies.Razor.SweetAlert2;
using Microsoft.AspNetCore.Components;
using MudBlazor;
using Ngsystem.FrontDentis.Components;
using Ngsystem.Infrastructure.Dtos;
using Ngsystem.Infrastructure.Infrastructure.Http;
using Refit;

namespace Ngsystem.FrontDentis.Pages.Reserva;

public class ModalReservaBase : ComponentBase
{
    [Parameter] public LisReservaResponseDto objReserva { get; set; } = new LisReservaResponseDto();

    [Inject] IReserva _reservaServicio { get; set; }
    public MudForm? form { get; set; }
    [Inject] ISnackbar _snackBar { get; set; }
    [Inject] IDialogService _dialogServicio { get; set; }
    [Inject] SweetAlertService _swal { get; set; }
    [Inject] NavigationManager _nav { get; set; }
    [CascadingParameter] MudDialogInstance MudDialog { get; set; }

    protected override void OnInitialized()
    {
        if (objReserva.FechaReserva == null)
            objReserva.FechaReserva = DateTime.Today;

        if (objReserva.FechaAtencion == null)
            objReserva.FechaAtencion = DateTime.Today;
    }

    public void Cancel() => MudDialog.Cancel();

    public async Task MostrarConfirmacion()
    {
        if (form is not null)
        {
            await form.Validate();
            if (!form.IsValid)
                return;
        }

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
        var request = new SaveReservaRequestDto
        {
            IdPaciente = objReserva.IdPaciente > 0 ? objReserva.IdPaciente : 0,
            EstadoReserva = objReserva.EstadoReserva ?? string.Empty,
            FechaReserva = objReserva.FechaReserva,
            FechaAtencion = objReserva.FechaAtencion,
            HoraAtencion = objReserva.HoraAtencion,
            MotivoConsulta = objReserva.MotivoConsulta ?? string.Empty,
            Observaciones = objReserva.Observaciones,
            Dni = objReserva.Dni
        };

        try
        {
            if (objReserva.Id == 0)
            {
                var response = await _reservaServicio.GrabarReserva(request);
                if (response.Status)
                {
                    _snackBar.Add("Reserva registrada correctamente", Severity.Success);
                    MudDialog.Close(DialogResult.Ok(true));
                }
                else
                {
                    _snackBar.Add("Hubo un error al guardar la reserva", Severity.Error);
                }
            }
            else
            {
                request.Id = objReserva.Id;
                var response = await _reservaServicio.UpdateReserva(request);
                if (response.Status)
                {
                    _snackBar.Add("Reserva actualizada correctamente", Severity.Success);
                    MudDialog.Close(DialogResult.Ok(true));
                }
                else
                {
                    _snackBar.Add("Hubo un error al guardar la reserva", Severity.Error);
                }
            }
        }
        catch (ApiException ex)
        {
            var content = ex.Content ?? string.Empty;
            if (content.Contains("no está registrado"))
            {
                MudDialog.Cancel();

                var result = await _swal.FireAsync(new SweetAlertOptions
                {
                    Title = "Paciente no encontrado",
                    Text = "El paciente con ese DNI no está registrado. ¿Desea ir a registrarlo ahora?",
                    Icon = SweetAlertIcon.Warning,
                    ShowConfirmButton = true,
                    ConfirmButtonText = "Sí, registrar",
                    ShowCancelButton = true,
                    CancelButtonText = "Cancelar"
                });

                if (result.IsConfirmed)
                    _nav.NavigateTo("/Paciente/Paciente?action=nuevo");
            }
            else
            {
                await _swal.FireAsync(new SweetAlertOptions
                {
                    Title = "Error",
                    Text = content,
                    Icon = SweetAlertIcon.Error
                });
            }
        }
    }
}
