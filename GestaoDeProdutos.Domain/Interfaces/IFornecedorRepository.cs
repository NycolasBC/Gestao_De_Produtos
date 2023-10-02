using GestaoDeProdutos.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoDeProdutos.Domain.Interfaces
{
    public interface IFornecedorRepository
    {
        public void AdicionarFornecedor(Fornecedor fornecedor);
        public void AtualizarFornecedor(Fornecedor fornecedor);
        public void RemoverFornecedor(Fornecedor fornecedor);
        public IList<Fornecedor> ObterTodosFornecedores();
        public Fornecedor ObterFornecedorPorId(int id);
    }
}
