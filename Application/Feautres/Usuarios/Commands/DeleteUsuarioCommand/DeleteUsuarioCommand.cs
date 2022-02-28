using Application.Interfaces;
using Application.Wrappers;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Feautres.Usuarios.Commands.DeleteUsuarioCommand
{
    public class DeleteUsuarioCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
    }
    public class DeleteUsuarioCommandHandler : IRequestHandler<DeleteUsuarioCommand, Response<int>>
    {
        private readonly IRepositoryAsync<Usuario> _repositoryAsync;

        public DeleteUsuarioCommandHandler(IRepositoryAsync<Usuario> repositoryAsync)
        {
            _repositoryAsync = repositoryAsync;
        }

        public async Task<Response<int>> Handle(DeleteUsuarioCommand request, CancellationToken cancellationToken)
        {
            var usuario = await _repositoryAsync.GetByIdAsync(request.Id);

            if (usuario == null)
            {
                throw new KeyNotFoundException($"Registro no encontrado con el id {request.Id}");
            }
            else
            {
                await _repositoryAsync.DeleteAsync(usuario);

                return new Response<int>(usuario.Id);
            }
        }
    }
}
