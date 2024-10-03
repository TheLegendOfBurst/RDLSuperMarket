using System;
using System.Collections.Generic;

namespace RDLSuperMarket.ORM;

public partial class TbProduto
{
    public int Id { get; set; }

    public string Nome { get; set; } = null!;

    public decimal Preco { get; set; }

    public int Quantidade { get; set; }

    public byte[]? NotasFiscais { get; set; }

    public virtual ICollection<TbVenda> TbVenda { get; set; } = new List<TbVenda>();
    public object Notaff { get; internal set; }
}
