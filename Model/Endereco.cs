using RDLSuperMarket.ORM;

namespace RDLSuperMarket.Model
{
    public class Endereco
    {
        public int Id { get; set; }

        public string Logadouro { get; set; } = null!;

        public string Cidade { get; set; } = null!;

        public string Estado { get; set; } = null!;

        public int Cep { get; set; }

        public string Pontoreferencia { get; set; } = null!;

        public int Numero { get; set; }

        public int Fkcliente { get; set; }

        public virtual TbCliente FkclienteNavigation { get; set; } = null!;
    }
}
