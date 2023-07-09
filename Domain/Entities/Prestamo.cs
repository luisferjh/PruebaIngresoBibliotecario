using Domain.Interfaces;
using Domain.Types;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Prestamo
    {
        private readonly IUnitOfWork _unitOfWork;

        public Prestamo(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [Key]
        public Guid Id { get; set; }
        public Guid Isbn { get; set; }
        public string IdentificacionUsuario { get; set; }
        public int TipoUsuario { get; set; }
        public DateTime FechaMaximaDevolucion { get; set; }

        public async Task<bool> ValidarPrestamosInvitado(TipoUsuario tipoUsuario, string identifiacion)
        {
            if (tipoUsuario == Types.TipoUsuario.INVITADO)
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
                case Types.TipoUsuario.AFILIADO:
                    fechaDevolucion = CalcularFechaSinFinDeSemana(fechaDevolucion, 10);
                    break;
                case Types.TipoUsuario.EMPLEADO:
                    fechaDevolucion = CalcularFechaSinFinDeSemana(fechaDevolucion, 8);
                    break;
                case Types.TipoUsuario.INVITADO:
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
