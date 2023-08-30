using GestaoDeProdutos.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoDeProdutos.Domain.Interfaces
{
    public interface IProdutoRepository
    {
        //o que fazer
        public void AdicionarProduto(Produto produto);
        public void Atualizar(Produto produto);
        public IList<Produto> ObterTodosProdutos();
        public Produto ObterProdutoPorId(int id);
        public void AtivarProduto();
        public void ReativarProduto();
    }
}
