using GestaoDeProdutos.Domain.Entities;
using GestaoDeProdutos.Domain.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoDeProduto.Data.Repositories
{
    public class ProdutoRepository : IProdutoRepository
    {
        #region - Atributos e Construtor

        private readonly string _produtoCaminhoArquivo;

        public ProdutoRepository()
        {
            _produtoCaminhoArquivo = Path.Combine(Directory.GetCurrentDirectory(), "FileJsonData", "produto.json");
        }

        #endregion

        #region - Funções de repositorio

        public void AdicionarProduto(Produto produto)
        {
            List<Produto> produtos = new List<Produto>();
            int proximoCodigo = ObterProximoCodigoDisponivel();
            produtos.Add(produto);
            EscreverProdutosNoArquivo(produtos);
        }

        public void AtivarProduto()
        {
            throw new NotImplementedException();
        }

        public void Atualizar(Produto produto)
        {
            throw new NotImplementedException();
        }

        public Produto ObterProdutoPorId(int id)
        {
            throw new NotImplementedException();
        }

        public IList<Produto> ObterTodosProdutos()
        {
            throw new NotImplementedException();
        }

        public void ReativarProduto()
        {
            throw new NotImplementedException();
        }
        #endregion

        #region - Funções do arquivo
        private List<Produto> LerProdutosDoArquivo()
        {
            if (!System.IO.File.Exists(_produtoCaminhoArquivo))
            {
                return new List<Produto>();
            }

            string json = System.IO.File.ReadAllText(_produtoCaminhoArquivo);
            return JsonConvert.DeserializeObject<List<Produto>>(json);
        }

        private int ObterProximoCodigoDisponivel()
        {
            List<Produto> produtos = LerProdutosDoArquivo();
            if (produtos.Any())
            {
                return produtos.Max(p => p.Codigo) + 1;
            }
            else
            {
                return 1;
            }
        }

        private void EscreverProdutosNoArquivo(List<Produto> produtos)
        {
            string json = JsonConvert.SerializeObject(produtos);
            System.IO.File.WriteAllText(_produtoCaminhoArquivo, json);
        }

        #endregion
    }
}
