using Microsoft.AspNetCore.Components;
using Ngsystem.Infrastructure.Dtos;
using Ngsystem.Infrastructure.Infrastructure.Http;

namespace Ngsystem.FrontDentis.Pages.Paciente;

public class PacientePerfilBase : ComponentBase
{
    [Parameter] public int Id { get; set; }

    [Inject] private IPaciente? PacienteService { get; set; }
    [Inject] private NavigationManager? Navigation { get; set; }

    protected bool _loading = true;
    protected string _nombrePaciente = "";
    protected string _apellidoPaciente = "";
    protected string _dniPaciente = "";

    protected override async Task OnInitializedAsync()
    {
        await CargarPaciente();
    }

    protected async Task CargarPaciente()
    {
        _loading = true;

        var response = await PacienteService!.ListaPaciente();
        if (response is { Status: true, Lista: not null })
        {
            var paciente = response.Lista.FirstOrDefault(p => p.Id == Id);
            if (paciente is not null)
            {
                _nombrePaciente = paciente.Nombre ?? "";
                _apellidoPaciente = paciente.Apellido ?? "";
                _dniPaciente = paciente.Dni ?? "";
            }
        }

        _loading = false;
    }

    protected void VolverLista()
    {
        Navigation?.NavigateTo("/Paciente/Paciente");
    }
}
