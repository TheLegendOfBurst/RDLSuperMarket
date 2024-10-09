using System.Collections.Generic;
using RDLSuperMarket.Model;

namespace RDLSuperMarket.Repositories
{
    public interface IProdutoRepository
    {
        IEnumerable<Produto> GetAll();
        Produto GetById(int id);
        void Add(Produto produto);
        void Update(Produto produto);
        void Delete(int id);
    }
}

