using Application.Contratos;
using Application.Utils;
using Domain.Dtos;
using Domain.Entities;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Application.Implementacion
{
    public class PrestamoService: IPrestamoService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapping _mapping;
        private readonly PrestamoCalculador _prestamoCalculador;

        public PrestamoService(   
            IUnitOfWork unitOfWork,
            IMapping mapping,
            PrestamoCalculador prestamoCalculador)
        {
            _unitOfWork = unitOfWork;
            _mapping = mapping;
            _prestamoCalculador = prestamoCalculador;
        }

        public async Task<Prestamo> GetPrestamoAsync(Guid idPrestamo)
        {
            return await _unitOfWork.PrestamoRepository.GetPrestamoAsync(idPrestamo);                     
        }

        public async Task<ResponseServiceDTO> InsertPrestamoAsync(CreatePrestamoDTO createPrestamoDTO)
        {
            try
            {
                //validar que el usuario invitado solo tenga un prestamo
                var usuarioInvitadoTienePrestamos = await _prestamoCalculador.ValidarPrestamosInvitado(createPrestamoDTO.TipoUsuario, createPrestamoDTO.IdentificacionUsuario);
                if (usuarioInvitadoTienePrestamos)
                {
                    return new ResponseServiceDTO
                    {
                        Message = "",
                        Result = false,
                        Response = new
                        {
                            mensaje = $"El usuario con identificacion {createPrestamoDTO.IdentificacionUsuario} ya tiene un libro prestado por lo cual no se le puede realizar otro prestamo"
                        }
                    };
                }

                // calcular fecha de devolucion
                Prestamo prestamo = _mapping.Map<Prestamo, CreatePrestamoDTO>(createPrestamoDTO);
                prestamo.Id = Guid.NewGuid();
                prestamo.FechaMaximaDevolucion = _prestamoCalculador.CalcularFechaDevolucion(createPrestamoDTO.TipoUsuario);
                await _unitOfWork.PrestamoRepository.AddPrestamoAsync(prestamo);
                var result = await _unitOfWork.SaveAsync();
                if (result <= 0)
                {
                    return new ResponseServiceDTO
                    {
                        Result = false,                        
                        Response = new
                        {
                            mensaje = "Ha ocurrido un error guardando el prestamo"
                        }
                    };
                }

                return new ResponseServiceDTO
                {
                    Result = true,
                    Message = "",
                    Response = new SuccessPrestamoCreatedDTO
                    {
                        id = prestamo.Id,
                        fechaMaximaDevolucion = prestamo.FechaMaximaDevolucion.ToString("MM/dd/yyyy")
                    }
                };

            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
