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

namespace Application.Feautres.Usuarios.Commands.CreateClienteCommand
{
    public class CreateUsuarioCommand : IRequest<Response<int>>
    {
        public string Nombre { get; set; }

        public string Email { get; set; }

        public string Telefono { get; set; }

        public string Username { get; set; }

    }

    public class CreateUsuarioCommandHandler : IRequestHandler<CreateUsuarioCommand, Response<int>>
    {
        private readonly IRepositoryAsync<Usuario> _repositoryAsync;
        private readonly IMapper _mapper;

        public CreateUsuarioCommandHandler(IRepositoryAsync<Usuario> repositoryAsync, IMapper mapper)
        {
            _repositoryAsync = repositoryAsync;
            _mapper = mapper;
        }

        public async Task<Response<int>> Handle(CreateUsuarioCommand request, CancellationToken cancellationToken)
        {
            var nuevoRegistro = _mapper.Map<Usuario>(request);
            var data = await _repositoryAsync.AddAsync(nuevoRegistro);

            return new Response<int>(data.Id);
        }
    }
}

