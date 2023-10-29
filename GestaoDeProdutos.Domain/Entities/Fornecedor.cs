//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace GestaoDeProdutos.Domain.Entities
//{
//    public class Fornecedor : EntidadeBase
//    {
//        #region - Propriedades

//        public string Nome { get; set; }
//        public string RazaoSocial { get; set; }
//        public string CNPJ { get; set; }
//        public bool Ativo { get; set; }
//        public DateTime DataCadastro { get; set; }
//        public string EmailContato { get; set; }

//        #endregion

//        #region Construtores

//        public Fornecedor(Guid codigoId, string nome, string razaoSocial, string cNPJ, bool ativo, DateTime dataCadastro, string emailContato)
//        {
//            CodigoId = codigoId;
//            Nome = nome;
//            RazaoSocial = razaoSocial;
//            CNPJ = cNPJ;
//            Ativo = ativo;
//            DataCadastro = dataCadastro;
//            EmailContato = emailContato;
//        }

//        public Fornecedor(string nome, string razaoSocial, string cNPJ, bool ativo, DateTime dataCadastro, string emailContato)
//        {
//            Nome = nome;
//            RazaoSocial = razaoSocial;
//            CNPJ = cNPJ;
//            Ativo = ativo;
//            DataCadastro = dataCadastro;
//            EmailContato = emailContato;
//        }

//        #endregion
//    }
//}
