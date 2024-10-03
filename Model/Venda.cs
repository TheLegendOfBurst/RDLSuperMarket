using RDLSuperMarket.ORM;
using System.Text.Json.Serialization;

namespace RDLSuperMarket.Model
{
    public class Venda
    {
        public int Id { get; set; }

        public byte[]? Notafv { get; set; }

        public decimal Valor { get; set; }

        [JsonIgnore]
        public int FkCliente { get; set; }

        [JsonIgnore]
        public int FkProduto { get; set; }

        
        public virtual TbCliente FkClienteNavigation { get; set; } = null!;
        public virtual TbProduto FkProdutoNavigation { get; set; } = null!;

        public DateTime DataVenda { get; set; }

        public string Descricao { get; set; }
    }
}