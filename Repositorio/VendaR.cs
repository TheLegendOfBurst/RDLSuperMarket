using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RDLSuperMarket.Model;
using RDLSuperMarket.ORM;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace RDLSuperMarket.Repositorio
{
    public class VendaR
    {
        private readonly RdlSuperMarketContext _context;

        public VendaR(RdlSuperMarketContext context)
        {
            _context = context;
        }

        public void Add(Venda venda)
        {
            
            var tbVenda = new TbVenda()
            {
                Valor = venda.Valor,
                Fkcliente = venda.FkCliente,
                Fkproduto = venda.FkProduto,
                
            };

            _context.TbVenda.Add(tbVenda);

            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            
            var tbVenda = _context.TbVenda.FirstOrDefault(v => v.Id == id);

            
            if (tbVenda != null)
            {
                
                _context.TbVenda.Remove(tbVenda);

                
                _context.SaveChanges();
            }
            else
            {
                throw new Exception("Venda não encontrada.");
            }
        }

        public List<Venda> GetAll()
        {
            List<Venda> listVendas = new List<Venda>();

            var listTb = _context.TbVenda.ToList();

            foreach (var item in listTb)
            {
                var venda = new Venda
                {
                    Id = item.Id,
                    Valor = item.Valor,
                    FkCliente = item.Fkcliente,
                    FkProduto = item.Fkproduto,
                    
                };

                listVendas.Add(venda);
            }

            return listVendas;
        }

        public Venda GetById(int id)
        {
            
            var item = _context.TbVenda.FirstOrDefault(v => v.Id == id);

            
            if (item == null)
            {
                return null; 
            }

            
            var venda = new Venda
            {
                Id = item.Id,
                Valor = item.Valor,
                FkCliente = item.Fkcliente,
                FkProduto = item.Fkproduto,
                
            };

            return venda; 
        }

        public void Update(Venda venda)
        {
            
            var tbVenda = _context.TbVenda.FirstOrDefault(v => v.Id == venda.Id);

            
            if (tbVenda != null)
            {
                
                tbVenda.Valor = venda.Valor;
                tbVenda.Fkcliente = venda.FkCliente;
                tbVenda.Fkproduto = venda.FkProduto;

                
                _context.TbVenda.Update(tbVenda);

                
                _context.SaveChanges();
            }
            else
            {
                throw new Exception("Venda não encontrada.");
            }
        }
    }
}
