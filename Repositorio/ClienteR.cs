using Microsoft.AspNetCore.Http;
using RDLSuperMarket.Model;
using RDLSuperMarket.ORM;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace RDLSuperMarket.Repositorio
{
    public class ClienteR 
    {
        private readonly RdlSuperMarketContext _context;

        public ClienteR(RdlSuperMarketContext context)
        {
            _context = context;
        }

        public void Add(Cliente cliente, IFormFile documentoId)
        {
            byte[] documentoBytes = null;
            if (documentoId != null && documentoId.Length > 0)
            {
                using (var memoryStream = new MemoryStream())
                {
                    documentoId.CopyTo(memoryStream);
                    documentoBytes = memoryStream.ToArray();
                }
            }

            var tbCliente = new TbCliente
            {
                Nome = cliente.Nome,
                Telefone = cliente.Telefone,
                Endereco = cliente.Endereco,
                Documentoid = documentoBytes
            };

            _context.TbClientes.Add(tbCliente);
            _context.SaveChanges();
        }

        public void Update(Cliente cliente, IFormFile documentoId)
        {
            var tbCliente = _context.TbClientes.FirstOrDefault(c => c.Id == cliente.Id);
            if (tbCliente != null)
            {
                tbCliente.Nome = cliente.Nome;
                tbCliente.Telefone = cliente.Telefone;
                tbCliente.Endereco = cliente.Endereco;

                if (documentoId != null && documentoId.Length > 0)
                {
                    using (var memoryStream = new MemoryStream())
                    {
                        documentoId.CopyTo(memoryStream);
                        tbCliente.Documentoid = memoryStream.ToArray();
                    }
                }

                _context.TbClientes.Update(tbCliente);
                _context.SaveChanges();
            }
            else
            {
                throw new Exception("Cliente não encontrado.");
            }
        }

        public void Delete(int id)
        {
            var tbCliente = _context.TbClientes.FirstOrDefault(c => c.Id == id);
            if (tbCliente != null)
            {
                _context.TbClientes.Remove(tbCliente);
                _context.SaveChanges();
            }
            else
            {
                throw new Exception("Cliente não encontrado.");
            }
        }

        public Cliente GetById(int id)
        {
            var item = _context.TbClientes.FirstOrDefault(c => c.Id == id);
            if (item == null)
            {
                return null;
            }

            return new Cliente
            {
                Id = item.Id,
                Nome = item.Nome,
                Telefone = item.Telefone,
                Endereco = item.Endereco,
                Documentoid = item.Documentoid
            };
        }

        public List<Cliente> GetAll()
        {
            return _context.TbClientes.Select(item => new Cliente
            {
                Id = item.Id,
                Nome = item.Nome,
                Telefone = item.Telefone,
                Endereco = item.Endereco,
                Documentoid = item.Documentoid
            }).ToList();
        }

        internal void Add(Cliente novoCliente)
        {
            throw new NotImplementedException();
        }

        internal void Update(Cliente clienteExistente)
        {
            throw new NotImplementedException();
        }
    }
}
