using Microsoft.AspNetCore.Components;
using Ngsystem.Infrastructure.Infrastructure.Http;
using Ngsystem.Infrastructure.Dtos;
using MudBlazor;

namespace Ngsystem.FrontDentis.Pages.Paciente
{
    public class WeatherBase : ComponentBase
    {
        [Inject] IPaciente? _listaPaciente { get; set; }
        [Inject] IDialogService? _dialogServicio { get; set; }
        [Inject] ISnackbar? _snackBar { get; set; }

        public string searchString1 = "";
        public LisPacienteResponseDto selectedItem1 = null;
        public bool _loading = false;
        public bool estadoLoad = false;

        public IEnumerable<LisPacienteResponseDto>? listaPacienteDto { get; set; }

        protected override async Task OnInitializedAsync()
        {
            await CargaLista();
        }

        public async Task CargaLista()
        {
            this.estadoLoad = true;
            var response = await _listaPaciente.ListaPaciente();
            if (response.Status == true)
            {
                this.listaPacienteDto = response.Lista.ToList();
            }
            this.estadoLoad = false;
        }

        public async Task AbrirEditarPacientes(LisPacienteResponseDto model)
        {
            var parametros = new DialogParameters { ["objPaciente"] = model };
            var options = new DialogOptions
            {
                MaxWidth = MaxWidth.Large, 
                FullWidth = true
            };
            var dialogo = _dialogServicio.Show<ModalPaciente>("Editar Paciente", parametros, options);
            var resultado = await dialogo.Result;
            if (!resultado.Canceled)
            {
                await CargaLista();
                _snackBar?.Add("Paciente actualizado correctamente", Severity.Success);
            }
        }

        public async Task MostrarDetalle()
        {
            _snackBar?.Add("Funcionalidad en desarrollo", Severity.Info);
        }

        public async Task NuevoPaciente()
        {
            var options = new DialogOptions
            {
                MaxWidth = MaxWidth.Large, 
                FullWidth = true
            };
            var dialogo = _dialogServicio.Show<ModalPaciente>("Nuevo Paciente", options);
            var resultado = await dialogo.Result;
            if (!resultado.Canceled)
            {
                await CargaLista();
                _snackBar?.Add("Paciente creado correctamente", Severity.Success);
            }
        }

        public bool FilterFunc1(LisPacienteResponseDto element) => FilterFunc(element, searchString1);

        public bool FilterFunc(LisPacienteResponseDto element, string searchString)
        {
            if (string.IsNullOrWhiteSpace(searchString))
                return true;


            var searchTerm = searchString.ToLowerInvariant();


            if (!string.IsNullOrEmpty(element.Nombre) &&
                element.Nombre.ToLowerInvariant().Contains(searchTerm))
                return true;


            if (!string.IsNullOrEmpty(element.Apellido) &&
                element.Apellido.ToLowerInvariant().Contains(searchTerm))
                return true;

            if (!string.IsNullOrEmpty(element.Dni) &&
                element.Dni.Contains(searchTerm))
                return true;

            return false;
        }
    }
}