using GestaoDeProdutos.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoDeProdutos.Application.Interfaces
{
    public interface IProdutoService
    {
        public void AdicionarProduto(NovoProdutoViewModel produto);
        public void Atualizar(ProdutoViewModel produto);
        public IList<ProdutoViewModel> ObterTodosProdutos();
        public ProdutoViewModel ObterProdutoPorId(int id);
        public void AtivarProduto();
        public void ReativarProduto();
    }
}
