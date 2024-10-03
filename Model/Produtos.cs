using System.Text.Json.Serialization;

namespace RDLSuperMarket.Model
{
    public class Produto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public double Preco { get; set; }
        public double[]? NotasFiscais { get; set; }

        [JsonIgnore]
        public string? NotasFiscaisBase64 => NotasFiscais != null ? Convert.ToBase64String(ConvertNotasFiscaisToBytes(NotasFiscais)) : null;

        public string UrlFoto { get; set; }

        private byte[] ConvertNotasFiscaisToBytes(double[] notas)
        {
            var notasStrings = string.Join(",", notas);
            return System.Text.Encoding.UTF8.GetBytes(notasStrings);
        }
    }
}
