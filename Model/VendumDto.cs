namespace RDLSuperMarket.Model
{
    public class VendumDto
    {
        public int Quantidade { get; set; }

        public decimal Valor { get; set; }

        public int FkCliente { get; set; }

        public int FkProduto { get; set; }

        public IFormFile Notafv { get; set; }

    }
}
