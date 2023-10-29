using AutoMapper;
using GestaoDeProdutos.Application.Interfaces;
using GestaoDeProdutos.Application.ViewModels;
using GestaoDeProdutos.Domain.Entities;
using GestaoDeProdutos.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoDeProdutos.Application.Services
{
    public class ProdutoService : IProdutoService
    {
        #region - Construtores

        private readonly IProdutoRepository _produtoRepository;
        private IMapper _mapper;

        public ProdutoService(IProdutoRepository produtoRepository, IMapper mapper)
        {
            _produtoRepository = produtoRepository;
            _mapper = mapper;
        }

        #endregion

        #region - Funções

        public async Task Adicionar(NovoProdutoViewModel novoProdutoViewModel)
        {
            var novoProduto = _mapper.Map<Produto>(novoProdutoViewModel);

            Produto p = new Produto(novoProdutoViewModel.Descricao, novoProdutoViewModel.Descricao, novoProdutoViewModel.Ativo, novoProdutoViewModel.Valor, novoProdutoViewModel.DataCadastro, novoProdutoViewModel.Imagem, novoProdutoViewModel.QuantidadeEstoque);

            await _produtoRepository.Adicionar(novoProduto);

        }

        public async Task Atualizar(Guid id, AtualizarProdutoViewModel produto)
        {
            var buscaProduto = await _produtoRepository.ObterPorId(id);

            if (buscaProduto == null) throw new ApplicationException("Não é possível atualizar um produto que não existe!");

            var produtoAlterado = _mapper.Map<Produto>(produto);

            buscaProduto.AlterarProduto(produtoAlterado);

            await _produtoRepository.Atualizar(buscaProduto);
        }

        public async Task AlterarPreco(Guid id, decimal valor)
        {
            var buscaProduto = await _produtoRepository.ObterPorId(id);

            if (buscaProduto == null) throw new ApplicationException("Não é possível alterar o preço de um produto que não existe!");

            buscaProduto.AlterarPreco(valor);

            await _produtoRepository.AlterarPreco(buscaProduto);

        }

        public async Task AtualizarEstoque(Guid id, int quantidade)
        {
            var buscaProduto = await _produtoRepository.ObterPorId(id);

            if (buscaProduto == null) throw new ApplicationException("Não é possível alterar o estoque de um produto que não existe!");

            int quantidadeEstoque = buscaProduto.QuantidadeEstoque;

            if(quantidadeEstoque - quantidade < 0) throw new ApplicationException("Não é possível retirar mais do que o estoque possui!");

            if(quantidade < 0)
            {
                buscaProduto.DebitarEstoque(quantidade);
            }
            else if(quantidade > 0)
            {
                buscaProduto.ReporEstoque(quantidade);
            }

            await _produtoRepository.AtualizarEstoque(buscaProduto);

        }

        public async Task Desativar(Guid id)
        {
            var buscaProduto = await _produtoRepository.ObterPorId(id);

            if (buscaProduto == null) throw new ApplicationException("Não é possível desativar um produto que não existe!");

            buscaProduto.Desativar();

            await _produtoRepository.Desativar(buscaProduto);

        }

        public async Task Reativar(Guid id)
        {
            var buscaProduto = await _produtoRepository.ObterPorId(id);

            if (buscaProduto == null) throw new ApplicationException("Não é possível reativar um produto que não existe!");

            buscaProduto.Reativar();

            await _produtoRepository.Reativar(buscaProduto);

        }

        public Task<IEnumerable<ProdutoViewModel>> ObterPorCategoria(int codigo)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ProdutoViewModel> ObterPorNome(string nome)
        {
            return _mapper.Map<IEnumerable<ProdutoViewModel>>(_produtoRepository.ObterPorNome(nome));
        }

        public Task<ProdutoViewModel> ObterPorId(Guid id)
        {
            return _mapper.Map<Task<ProdutoViewModel>>(_produtoRepository.ObterPorId(id));
        }

        public IEnumerable<ProdutoViewModel> ObterTodos()
        {
            return _mapper.Map<IEnumerable<ProdutoViewModel>>(_produtoRepository.ObterTodos());
        }

        #endregion
    }
}
