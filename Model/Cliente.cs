using RDLSuperMarket.ORM;
using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace RDLSuperMarket.Model
{
    public class Cliente
    {
        public int Id { get; set; }

        public string Nome { get; set; } = null!;

        
        public string Endereco { get; set; } = null!;

        public int Telefone { get; set; }

        public byte[]? Documentoid { get; set; }
        public object DocumentoId { get; internal set; }

        [JsonIgnore] // Ignora a serialização deste campo
        public string? DocBaseId64 => Documentoid != null ? Convert.ToBase64String(Documentoid) : null;

        public virtual ICollection<TbEndereco> TbEnderecos { get; set; } = new List<TbEndereco>();

        public virtual ICollection<TbVenda> TbVenda { get; set; } = new List<TbVenda>();
        public object Email { get; internal set; }
    }

}