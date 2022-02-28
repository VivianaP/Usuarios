using Application.DTOs;
using Application.Feautres.Usuarios.Commands.CreateClienteCommand;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Mappings
{
    public class GeneralProfile : Profile
    {
        public GeneralProfile()
        {
            CreateMap<Usuario, UsuarioDto>();
            CreateMap<CreateUsuarioCommand, Usuario>();
        }
    }
}
