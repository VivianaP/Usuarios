using Application.Feautres.Usuarios.Commands.CreateClienteCommand;
using Application.Feautres.Usuarios.Commands.DeleteUsuarioCommand;
using Application.Feautres.Usuarios.Commands.UpdateUsuarioCommand;
using Application.Feautres.Usuarios.Queries.GetAllUsuarios;
using Application.Feautres.Usuarios.Queries.GetUsuarioById;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers.Usuario
{
    public class UsuariosController : BaseApiController
    {
        //GET
        [HttpGet()]
        public async Task<IActionResult> Get()
        {
            return Ok(await Mediator.Send(new GetAllUsuariosQuery{}));
        }


        //GET
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await Mediator.Send(new GetUsuarioByIdQuery { Id = id }));
        }

        //POST
        [HttpPost]
        public async Task<IActionResult> Post(CreateUsuarioCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        //PUT
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, UpdateUsuarioCommand command)
        {
            if (id != command.Id)
                return BadRequest();
            return Ok(await Mediator.Send(command));
        }

        //DELETE
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await Mediator.Send(new DeleteUsuarioCommand { Id = id}));
        }

    }
}

 