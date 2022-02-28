using Application.Exceptions;
using Application.Interfaces;
using Application.Wrappers;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Feautres.Usuarios.Commands.UpdateUsuarioCommand
{
    public class UpdateUsuarioCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
        public string Nombre { get; set; }

        public string Email { get; set; }

        public string Telefono { get; set; }

        public string Username { get; set; }
    }
    public class UpdateUsuarioCommandHandler : IRequestHandler<UpdateUsuarioCommand, Response<int>>
    {
        private readonly IRepositoryAsync<Usuario> _repositoryAsync;
        private readonly IMapper _mapper;

        public UpdateUsuarioCommandHandler(IRepositoryAsync<Usuario> repositoryAsync, IMapper mapper)
        {
            _repositoryAsync = repositoryAsync;
            _mapper = mapper;
        }

        public async Task<Response<int>> Handle(UpdateUsuarioCommand request, CancellationToken cancellationToken)
        {
            var usuario = await _repositoryAsync.GetByIdAsync(request.Id);

            if (usuario == null)
            {
                throw new KeyNotFoundException($"Registro no encontrado con el id {request.Id}");
            }
            else
            {
                usuario.Nombre = request.Nombre;
                usuario.Email = request.Email;
                usuario.Telefono = request.Telefono;
                usuario.Username = request.Username;

                await _repositoryAsync.UpdateAsync(usuario);

                return new Response<int>(usuario.Id);
            }
        }
    }
}
