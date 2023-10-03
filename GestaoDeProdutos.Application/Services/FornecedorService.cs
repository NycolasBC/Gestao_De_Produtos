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
    public class FornecedorService : IFornecedorService
    {
        #region Construtores

        private readonly IFornecedorRepository _fornecedorRepository;
        private IMapper _mapper;

        public FornecedorService(IFornecedorRepository fornecedorRepository, IMapper mapper)
        {
            _fornecedorRepository = fornecedorRepository;
            _mapper = mapper;
        }

        #endregion

        #region Funções

        public bool AdicionarFornecedor(NovoFornecedorViewModel fornecedor)
        {
            try
            {
                var novoFornecedor = _mapper.Map<Fornecedor>(fornecedor);
                _fornecedorRepository.AdicionarFornecedor(novoFornecedor);
                return true;
            }
            catch { return false; }
            
        }

        public bool AtualizarFornecedor(FornecedorViewModel fornecedor, int id)
        {
            try
            {
                var fornecedorAtualizado = _mapper.Map<Fornecedor>(fornecedor);
                _fornecedorRepository.AtualizarFornecedor(fornecedorAtualizado, id);
                return true;
            }
            catch { return false; }
            
        }

        public FornecedorViewModel ObterFornecedorPorId(int id)
        {
            return _mapper.Map<FornecedorViewModel>(_fornecedorRepository.ObterFornecedorPorId(id));
        }

        public IList<FornecedorViewModel> ObterTodosFornecedores()
        {
            return _mapper.Map<List<FornecedorViewModel>>(_fornecedorRepository.ObterTodosFornecedores());
        }

        public bool RemoverFornecedor(int id)
        {
            try
            {
                _fornecedorRepository.RemoverFornecedor(id);
                return true;
            }
            catch{ return false; }
        }


        #endregion
    }
}
