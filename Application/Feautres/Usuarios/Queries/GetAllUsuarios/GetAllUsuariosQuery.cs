using Application.DTOs;
using Application.Interfaces;
using Application.Wrappers;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Feautres.Usuarios.Queries.GetAllUsuarios
{
    public class GetAllUsuariosQuery : IRequest<Response<UsuarioDto>>
    {
        public class GetAllClientesQueryHandler : IRequestHandler<GetAllUsuariosQuery, Response<UsuarioDto>>
        {
            private readonly IRepositoryAsync<Usuario> _repositoryAsync;
            private readonly IMapper _mapper;

            public GetAllClientesQueryHandler(IRepositoryAsync<Usuario> repositoryAsync, IMapper mapper)
            {
                _repositoryAsync = repositoryAsync;
                _mapper = mapper;
            }

            public async Task<Response<UsuarioDto>> Handle(GetAllUsuariosQuery request, CancellationToken cancellationToken)
            {

                var usuario = await _repositoryAsync.ListAsync();
                if (usuario == null)
                {
                    throw new KeyNotFoundException($"Registros no encontrados");
                }
                else
                {
                    var dto = _mapper.Map<UsuarioDto>(usuario);
                    return new Response<UsuarioDto>(dto);
                }
            }
        }

    }
}
