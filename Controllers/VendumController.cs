using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RDLSuperMarket.Repositorio;
using RDLSuperMarket.Model;
using RDLSuperMarket.ORM;

namespace RDLSuperMarket.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VendumController : ControllerBase
    {
        private readonly VendumR _vendumRepo; // O repositório que contém GetAll()

        public object UrlDocumentoid { get; set; }

        public VendumController(VendumR vendumRepo)
        {
            _vendumRepo = vendumRepo;
        }
        [HttpGet("{id}/Notafv")]
        public IActionResult GetNotafv(int id)
        {
            // Busca o funcionário pelo ID
            var vendum = _vendumRepo.GetById(id);

            // Verifica se o funcionário foi encontrado
            if (vendum == null || vendum.Notafv == null)
            {
                return NotFound(new { Mensagem = "Venda não encontrado." });
            }

            // Retorna a foto como um arquivo de imagem
            return File(vendum.Notafv, "image/jpeg"); // Ou "image/png" dependendo do formato
        }
    }
}