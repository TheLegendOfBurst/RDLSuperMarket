using Azure.Core;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RDLSuperMarket.Model;
using RDLSuperMarket.ORM;
using System.Collections.Generic;
using System.IO;
using System.Linq;



namespace RDLSuperMarket.Repositorio
{
    public class VendumR
    {
       /* private readonly RdlsuperMarketContext _context;

        public VendumR(RdlsuperMarketContext context)
        {
            _context = context;
        }

        public void Add(Vendum vedum, IFormFile Notafv)
        {
            // Verifica se uma foto foi enviada
            byte[] fotoBytes = null;
            if (notafv != null && notafv.Length > 0)
            {
                using (var memoryStream = new MemoryStream())
                {
                    foto.CopyTo(memoryStream);
                    fotoBytes = memoryStream.ToArray();
                }
            }

            // Cria uma nova entidade do tipo TbFuncionario a partir do objeto Funcionario recebido
            var tbFuncionario = new TbFuncionario()
            {
                Nome = funcionario.Nome,
                Idade = funcionario.Idade,
                Foto = fotoBytes // Armazena a foto na entidade
            };

            // Adiciona a entidade ao contexto
            _context.TbFuncionarios.Add(tbFuncionario);

            // Salva as mudanças no banco de dados
            _context.SaveChanges();*/
    }
}