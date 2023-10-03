using GestaoDeProdutos.Application.ViewModels;
using GestaoDeProdutos.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoDeProdutos.Application.Interfaces
{
    public interface IFornecedorService
    {
        public bool AdicionarFornecedor(NovoFornecedorViewModel fornecedor);
        public bool AtualizarFornecedor(FornecedorViewModel fornecedor, int id);
        public bool RemoverFornecedor(int id);
        public IList<FornecedorViewModel> ObterTodosFornecedores();
        public FornecedorViewModel ObterFornecedorPorId(int id);
    }
}
