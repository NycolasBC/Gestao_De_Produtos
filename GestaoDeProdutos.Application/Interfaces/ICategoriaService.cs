using GestaoDeProdutos.Application.ViewModels;
using GestaoDeProdutos.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoDeProdutos.Application.Interfaces
{
    public interface ICategoriaService
    {
        public bool AdicionarCategoria(NovaCategoriaViewModel categoria);
        public bool AtualizarCategoria(CategoriaViewModel categoria, int id);
        public bool RemoverCategoria(int id);
        public List<CategoriaViewModel> ObterTodasCategorias();
        public CategoriaViewModel ObterCategoriaPorId(int id);
    }
}
