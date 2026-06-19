using Microsoft.AspNetCore.Components;
using MudBlazor;
using Ngsystem.Infrastructure.Dtos;
using Ngsystem.Infrastructure.Infrastructure.Http;
using CurrieTechnologies.Razor.SweetAlert2;

namespace Ngsystem.FrontDentis.Pages.Citas;

public class ModalAtencionCitaBase : ComponentBase
{
    [Parameter] public int IdCita { get; set; }

    [Inject] ICita _citaServicio { get; set; }
    [Inject] SweetAlertService _swal { get; set; }
    [CascadingParameter] MudDialogInstance MudDialog { get; set; }
    public MudForm? form { get; set; }

    public string? Diagnostico { get; set; }
    public string? TratamientoRealizado { get; set; }
    public string? Observaciones { get; set; }

    public void Cancel() => MudDialog.Cancel();

    public async Task Guardar()
    {
        if (form is not null)
        {
            await form.Validate();
            if (!form.IsValid)
                return;
        }

        var request = new UpdateCitaRequestDto
        {
            IdCita = IdCita,
            EstadoCita = "Atendida",
            Diagnostico = Diagnostico,
            TratamientoRealizado = TratamientoRealizado,
            Observaciones = Observaciones
        };

        try
        {
            var response = await _citaServicio.UpdateCita(request);
            if (response.Status)
            {
                MudDialog.Close(DialogResult.Ok(true));
                await _swal.FireAsync(new SweetAlertOptions
                {
                    Title = "Éxito",
                    Text = "Atención clínica registrada correctamente",
                    Icon = SweetAlertIcon.Success,
                    Timer = 2000,
                    ShowConfirmButton = false
                });
            }
            else
            {
                await _swal.FireAsync(new SweetAlertOptions
                {
                    Title = "Error",
                    Text = "Error al guardar la atención clínica",
                    Icon = SweetAlertIcon.Error
                });
            }
        }
        catch
        {
            await _swal.FireAsync(new SweetAlertOptions
            {
                Title = "Error",
                Text = "Error de conexión al guardar la atención clínica",
                Icon = SweetAlertIcon.Error
            });
        }
    }
}
