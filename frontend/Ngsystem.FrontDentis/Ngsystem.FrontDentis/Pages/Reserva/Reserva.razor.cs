using Microsoft.AspNetCore.Components;
using Ngsystem.Infrastructure.Dtos;
using Ngsystem.Infrastructure.Infrastructure.Http;
using MudBlazor;

namespace Ngsystem.FrontDentis.Pages.Reserva
{
    public class ReservaBase : ComponentBase
    {
        [Inject] IReserva? _reservaServicio { get; set; }
        [Inject] IDialogService? _dialogServicio { get; set; }
        [Inject] ISnackbar? _snackBar { get; set; }

        public string searchString1 = "";
        public LisReservaResponseDto selectedItem1 = null;
        public bool _loading = false;
        public bool estadoLoad = false;

        public IEnumerable<LisReservaResponseDto>? listaReservaDto { get; set; }

        protected override async Task OnInitializedAsync()
        {
            await CargarReservas();
        }

        public async Task CargarReservas()
        {
            estadoLoad = true;
            var response = await _reservaServicio.ListaReserva();
            if (response.Status)
            {
                listaReservaDto = response.Lista;
            }
            estadoLoad = false;
        }

        public async Task AbrirEditarReserva(LisReservaResponseDto model)
        {
            var parametros = new DialogParameters { ["objReserva"] = model };
            var options = new DialogOptions
            {
                MaxWidth = MaxWidth.Large,
                FullWidth = true
            };
            var dialogo = _dialogServicio.Show<ModalReserva>("Editar Reserva", parametros, options);
            var resultado = await dialogo.Result;
            if (!resultado.Canceled)
            {
                await CargarReservas();
                _snackBar?.Add("Reserva actualizada correctamente", Severity.Success);
            }
        }

        public async Task NuevaReserva()
        {
            var options = new DialogOptions
            {
                MaxWidth = MaxWidth.Large,
                FullWidth = true
            };
            var dialogo = _dialogServicio.Show<ModalReserva>("Nueva Reserva", options);
            var resultado = await dialogo.Result;
            if (!resultado.Canceled)
            {
                await CargarReservas();
                _snackBar?.Add("Reserva creada correctamente", Severity.Success);
            }
        }

        public async Task MostrarDetalle()
        {
            _snackBar?.Add("Funcionalidad en desarrollo", Severity.Info);
        }

        public bool FilterFunc1(LisReservaResponseDto reserva) => FilterFunc(reserva, searchString1);

        public bool FilterFunc(LisReservaResponseDto r, string searchString)
        {
            if (string.IsNullOrWhiteSpace(searchString))
                return true;

            var s = searchString.ToLowerInvariant();

            return (r.Dni?.ToLowerInvariant().Contains(s) ?? false)
                || (r.EstadoReserva?.ToLowerInvariant().Contains(s) ?? false)
                || (r.MotivoConsulta?.ToLowerInvariant().Contains(s) ?? false);
        }
    }
}
