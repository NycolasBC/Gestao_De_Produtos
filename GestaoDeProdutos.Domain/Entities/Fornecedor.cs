using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoDeProdutos.Domain.Entities
{
    public class Fornecedor
    {
        #region - Propriedades

        public int Codigo { get; set; }
        public string RazaoSocial { get; set; }
        public string CNPJ { get; set; }
        public bool Ativo { get; set; }
        public DateTime DataCadastro { get; set; }
        public string EmailContato { get; set; }

        #endregion

        #region Construtores

        public Fornecedor(int codigo, string razaoSocial, string cNPJ, bool ativo, DateTime dataCadastro, string emailContato)
        {
            Codigo = codigo;
            RazaoSocial = razaoSocial;
            CNPJ = cNPJ;
            Ativo = ativo;
            DataCadastro = dataCadastro;
            EmailContato = emailContato;
        }

        public Fornecedor()
        {
        }

        #endregion
    }
}
