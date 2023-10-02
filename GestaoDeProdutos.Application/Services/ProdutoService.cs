using AutoMapper;
using GestaoDeProdutos.Application.Interfaces;
using GestaoDeProdutos.Application.ViewModels;
using GestaoDeProdutos.Domain.Entities;
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
        #region Construtores

        private readonly IProdutoRepository _produtoRepository;
        private IMapper _mapper;

        public ProdutoService(IProdutoRepository produtoRepository, IMapper mapper)
        {
            _produtoRepository = produtoRepository;
            _mapper = mapper;
        }

        #endregion

        #region Funções

        public void AdicionarProduto(NovoProdutoViewModel produto)
        {
            var novoProduto = _mapper.Map<Produto>(produto);
            _produtoRepository.AdicionarProduto(novoProduto);
        }

        public void AtivarProduto()
        {
            throw new NotImplementedException();
        }

        public void Atualizar(ProdutoViewModel produto)
        {
            throw new NotImplementedException();
        }

        public ProdutoViewModel ObterProdutoPorId(int id)
        {
            throw new NotImplementedException();
        }

        public IList<ProdutoViewModel> ObterTodosProdutos()
        {
            throw new NotImplementedException();
        }

        public void ReativarProduto()
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
