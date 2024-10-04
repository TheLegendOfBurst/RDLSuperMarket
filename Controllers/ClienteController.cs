using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjetoWebAPI.Model;
using RDLSuperMarket.Model;
using RDLSuperMarket.Repositorio;


namespace RDLSuperMarket.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class ClienteController : ControllerBase
    {
        private readonly ClienteR _clienteRepo; // O repositório que contém GetAll()

        public ClienteController(ClienteR clienteRepo)
        {
            _clienteRepo = clienteRepo;
        }

        [HttpGet("{id}/foto")]
        public IActionResult GetFoto(int id)
        {
            // Busca o funcionário pelo ID
            var funcionario = _clienteRepo.GetById(id);

            // Verifica se o funcionário foi encontrado
            if (funcionario == null || funcionario.Foto == null)
            {
                return NotFound(new { Mensagem = "Foto não encontrada." });
            }

            // Retorna a foto como um arquivo de imagem
            return File(funcionario., "image/jpeg"); // Ou "image/png" dependendo do formato
        }

    }
}
