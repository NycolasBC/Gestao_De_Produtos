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
    public class CategoriaService : ICategoriaService
    {
        #region Construtores

        private readonly ICategoriaRepository _categoriaRepository;
        private IMapper _mapper;

        public CategoriaService(ICategoriaRepository categoriaRepository, IMapper mapper)
        {
            _categoriaRepository = categoriaRepository;
            _mapper = mapper;
        }

        #endregion

        #region Funções

        public bool AdicionarCategoria(NovaCategoriaViewModel categoria)
        {
            try
            {
                var novaCategoria = _mapper.Map<Categoria>(categoria);
                _categoriaRepository.AdicionarCategoria(novaCategoria);
                return true;
            }
            catch{ return false; }    
        }

        public bool AtualizarCategoria(CategoriaViewModel categoria, int id)
        {
            try
            {
                var categoriaAtualizada = _mapper.Map<Categoria>(categoria);
                _categoriaRepository.AtualizarCategoria(categoriaAtualizada, id);
                return true;
            }
            catch { return false; }
        }

        public CategoriaViewModel ObterCategoriaPorId(int id)
        {
            return _mapper.Map<CategoriaViewModel>(_categoriaRepository.ObterCategoriaPorId(id));
        }

        public List<CategoriaViewModel> ObterTodasCategorias()
        {
            return _mapper.Map<List<CategoriaViewModel>>(_categoriaRepository.ObterTodasCategorias());
        }

        public bool RemoverCategoria(int id)
        {
            try
            {
                _categoriaRepository.RemoverCategoria(id);
                return true;
            }
            catch { return false; }       
        }

        #endregion
    }
}
