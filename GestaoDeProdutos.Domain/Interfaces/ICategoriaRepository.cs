using GestaoDeProdutos.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoDeProdutos.Domain.Interfaces
{
    public interface ICategoriaRepository
    {
        public void AdicionarCategoria(Categoria categoria);
        public void AtualizarCategoria(Categoria categoria);
        public void RemoverCategoria(Categoria categoria);
        public IList<Categoria> ObterTodosCategorias();
        public Categoria ObterCategoriaPorId(int id);
    }
}
