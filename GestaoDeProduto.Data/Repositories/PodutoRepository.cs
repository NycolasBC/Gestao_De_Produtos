using GestaoDeProdutos.Domain.Entities;
using GestaoDeProdutos.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoDeProduto.Data.Repositories
{
    internal class PodutoRepository : IProdutoRepository
    {
        public void AdicionarProduto(Produto produto)
        {
            throw new NotImplementedException();
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
    }
}
