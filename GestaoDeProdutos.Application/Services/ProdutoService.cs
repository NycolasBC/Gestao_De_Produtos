using GestaoDeProdutos.Application.Interfaces;
using GestaoDeProdutos.Application.ViewModels;
using GestaoDeProdutos.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoDeProdutos.Application.Services
{
    public class ProdutoService : IProdutoService
    {
        private readonly IProdutoRepository _produtoRepository;

        public ProdutoService(IProdutoRepository produtoRepository)
        {
            _produtoRepository = produtoRepository;
        }

        public void Adiconar(NovoProdutoViewModel novoProdutoViewModel)
        {
            _produtoRepository.AdicionarProduto(new Domain.Entities.Produto(
                novoProdutoViewModel.Codigo,
                novoProdutoViewModel.Nome,
                novoProdutoViewModel.Estoque,
                novoProdutoViewModel.Valor,
                novoProdutoViewModel.Ativo,
                novoProdutoViewModel.DataCadastro
                ));
        }
    }
}
