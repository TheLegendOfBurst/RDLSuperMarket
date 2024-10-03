using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RDLSuperMarket.Model;
using RDLSuperMarket.Repositorio;


namespace RDLSuperMarket.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize] // Protegendo todos os métodos com autenticação
    public class ClienteController : ControllerBase
    {
        private readonly ClienteR _clienteRepo; // O repositório que contém GetAll()

        public ClienteController(ClienteR clienteRepo)
        {
            _clienteRepo = clienteRepo;
        }

        // GET: api/Cliente
        [HttpGet]
        public ActionResult<List<Cliente>> GetAll()
        {
            // Chama o repositório para obter todos os clientes
            var clientes = _clienteRepo.GetAll();

            // Verifica se a lista de clientes está vazia
            if (clientes == null || !clientes.Any())
            {
                return NotFound(new { Mensagem = "Nenhum cliente encontrado." });
            }

            // Retorna a lista de clientes com status 200 OK
            return Ok(clientes);
        }

        // GET: api/Cliente/{id}
        [HttpGet("{id}")]
        public ActionResult<Cliente> GetById(int id)
        {
            // Chama o repositório para obter o cliente pelo ID
            var cliente = _clienteRepo.GetById(id);

            // Se o cliente não for encontrado, retorna uma resposta 404
            if (cliente == null)
            {
                return NotFound(new { Mensagem = "Cliente não encontrado." });
            }

            // Retorna o cliente com status 200 OK
            return Ok(cliente);
        }

        // POST api/Cliente
        [HttpPost]
        public ActionResult<Cliente> Post([FromBody] Cliente novoCliente)
        {
            // Verifica se o cliente é nulo
            if (novoCliente == null)
            {
                return BadRequest(new { Mensagem = "Dados do cliente são obrigatórios." });
            }

            // Chama o método de adicionar do repositório
            _clienteRepo.Add(novoCliente);

            // Retorna o cliente criado com status 201 Created
            return CreatedAtAction(nameof(GetById), new { id = novoCliente.Id }, novoCliente);
        }

        // PUT api/Cliente/{id}
        [HttpPut("{id}")]
        public ActionResult<Cliente> Put(int id, [FromBody] Cliente clienteAtualizado)
        {
            // Busca o cliente existente pelo ID
            var clienteExistente = _clienteRepo.GetById(id);

            // Verifica se o cliente foi encontrado
            if (clienteExistente == null)
            {
                return NotFound(new { Mensagem = "Cliente não encontrado." });
            }

            // Atualiza os dados do cliente existente
            clienteExistente.Nome = clienteAtualizado.Nome;
            clienteExistente.Email = clienteAtualizado.Email;
            // Atualize outros campos conforme necessário

            // Chama o método de atualização do repositório
            _clienteRepo.Update(clienteExistente);

            // Retorna o cliente atualizado com status 200 OK
            return Ok(clienteExistente);
        }

        // DELETE api/Cliente/{id}
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            // Busca o cliente existente pelo ID
            var clienteExistente = _clienteRepo.GetById(id);

            // Verifica se o cliente foi encontrado
            if (clienteExistente == null)
            {
                return NotFound(new { Mensagem = "Cliente não encontrado." });
            }

            // Chama o método de exclusão do repositório
            _clienteRepo.Delete(id);

            // Retorna uma resposta de sucesso
            return Ok(new { Mensagem = "Cliente excluído com sucesso!" });
        }
    }
}
