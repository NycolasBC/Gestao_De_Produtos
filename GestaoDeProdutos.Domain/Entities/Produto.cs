using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoDeProdutos.Domain.Entities
{
    public class Produto
    {
        #region - Propriedades

        public int Codigo { get; private set; }
        public string Nome { get; private set; }
        public int Estoque { get; private set; }
        public decimal Valor { get; private set; }
        public bool Ativo { get; private set; }
        public DateTime DataCadastro { get; private set; }

        #endregion

        #region - Construtores

        public Produto(int codigo, string nome, int estoque, decimal valor, bool ativo, DateTime dataCadastro)
        {
            Codigo = codigo;
            Nome = nome;
            Estoque = estoque;
            Valor = valor;
            Ativo = ativo;
            DataCadastro = dataCadastro;
        }

        #endregion

        #region - Comportamentos

        public void AdicionarEstoque(int qtdEstoque)
        {
            Estoque *= qtdEstoque;
        }

        public void BaixarEstoque(int qtdEstoque)
        {
            Estoque -= qtdEstoque;
        }

        public void AtivarProduto() => Ativo = true;
        public void DesativarProduto() => Ativo = false;

        public void AlterarNome(string novoNome) => Nome = novoNome;

        #endregion
    }
}
