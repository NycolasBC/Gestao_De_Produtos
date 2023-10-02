using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoDeProdutos.Domain.Entities
{
    public class Fornecedor
    {
        #region Propriedades

        public int Codigo { get; private set; }
        public string RazaoSocial { get; private set; }
        public string CNPJ { get; private set; }
        public bool Ativo { get; private set; }
        public DateTime DataCadastro { get; private set; }
        public string EmailContato { get; private set; }

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

        #endregion
    }
}
