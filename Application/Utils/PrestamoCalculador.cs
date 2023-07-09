using Domain.Dtos;
using Domain.Interfaces;
using Domain.Types;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Application.Utils
{
    public class PrestamoCalculador
    {
        private readonly IUnitOfWork _unitOfWork;

        public PrestamoCalculador(
            IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> ValidarPrestamosInvitado(TipoUsuario tipoUsuario, string identifiacion) 
        {
            if (tipoUsuario == TipoUsuario.INVITADO)
            {
                var usuarioInvitadoTienePrestamos = await _unitOfWork.PrestamoRepository.UsuarioTienePrestamoAsync(identifiacion);
                return usuarioInvitadoTienePrestamos;
            }
            return false;
        }

        public DateTime CalcularFechaDevolucion(TipoUsuario tipoUsuario)
        {
            DateTime fechaDevolucion = DateTime.Today;

            switch (tipoUsuario)
            {
                case TipoUsuario.AFILIADO:
                    fechaDevolucion = CalcularFechaSinFinDeSemana(fechaDevolucion, 10);
                    break;
                case TipoUsuario.EMPLEADO:
                    fechaDevolucion = CalcularFechaSinFinDeSemana(fechaDevolucion, 8);
                    break;
                case TipoUsuario.INVITADO:
                    fechaDevolucion = CalcularFechaSinFinDeSemana(fechaDevolucion, 7);
                    break;
                default:
                    throw new ArgumentException("Tipo de usuario inválido.");
            }

            return fechaDevolucion;
        }

        private static DateTime CalcularFechaSinFinDeSemana(DateTime fechaInicial, int dias)
        {
            DateTime fechaCalculada = fechaInicial;
            int diasSumados = 0;

            while (diasSumados < dias)
            {
                fechaCalculada = fechaCalculada.AddDays(1);

                // Verificar si es sábado o domingo
                if (fechaCalculada.DayOfWeek != DayOfWeek.Saturday && fechaCalculada.DayOfWeek != DayOfWeek.Sunday)
                {
                    diasSumados++;
                }
            }

            return fechaCalculada;
        }
    }
}
