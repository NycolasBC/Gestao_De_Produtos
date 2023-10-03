using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace GestaoDeProdutos.Application.ViewModels
{
    public class NovaCategoriaViewModel
    {
        #region Propriedades

        [JsonIgnore]
        public int Codigo { get; set; }
        public string Descricao { get; set; }

        #endregion
    }
}
