using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace GestaoDeProdutos.Application.ViewModels
{
    public class NovoFornecedorViewModel
    {
        #region - Propriedades

        [JsonIgnore]
        public int Codigo { get; set; }
        public string RazaoSocial { get; set; }
        public string CNPJ { get; set; }
        public bool Ativo { get; set; }
        [JsonIgnore]
        public DateTime DataCadastro { get; set; }
        public string EmailContato { get; set; }

        #endregion
    }
}
