using GestaoDeProdutos.Application.Interfaces;
using GestaoDeProdutos.Application.Services;
using GestaoDeProdutos.Application.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace GestaoDeProdutos.WebApi.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class CategoriaController : ControllerBase
    {
        #region - Propriedades e Construtores

        private readonly ICategoriaService _categoriaService;

        public CategoriaController(ICategoriaService categoriaService)
        {
            _categoriaService = categoriaService;
        }

        #endregion

        #region - CRUD

        [HttpGet(Name = "BuscarCategorias")]
        public IActionResult Get()
        {
            try
            {
                return Ok(_categoriaService.ObterTodasCategorias());
            }
            catch
            {
                return BadRequest("Nenhuma categoria salva");
            }
        }


        [HttpGet("{id}", Name = "BuscarCategoriasPorId")]
        public IActionResult Get(int id)
        {
            try
            {
                return Ok(_categoriaService.ObterCategoriaPorId(id));
            }
            catch
            {
                return BadRequest("Nenhuma categoria salva");
            }
        }


        [HttpPost(Name = "AdicionarCategoria")]
        public IActionResult Post(NovaCategoriaViewModel novaCategoriaViewModel)
        {
            try
            {
                var cadastradaComSucesso = _categoriaService.AdicionarCategoria(novaCategoriaViewModel);

                if (cadastradaComSucesso)
                {
                    return Ok("Categoria cadastrada com sucesso");
                }
                else
                {
                    return BadRequest("Houve um erro ao cadastrar a categoria");
                }
            }
            catch
            {
                return BadRequest("Houve um erro ao cadastrar a categoria");
            }

        }


        [HttpPut("{id}", Name = "AtualizarCategorias")]
        public IActionResult Put([FromBody]CategoriaViewModel categoriaViewModel, int id)
        {
            try
            {
                var atualizadaComSucesso = _categoriaService.AtualizarCategoria(categoriaViewModel, id);

                if (atualizadaComSucesso)
                {
                    return Ok("Categoria atualizada com sucesso");
                }
                else
                {
                    return BadRequest("Houve um erro ao atualizar a categoria");
                }
            }
            catch
            {
                return BadRequest("Houve um erro ao atualizar a categoria");
            }
        }


        [HttpDelete("{id}", Name = "RemoverCategorias")]
        public IActionResult Delete(int id)
        {
            try
            {
                var removidaComSucesso = _categoriaService.RemoverCategoria(id);

                if (removidaComSucesso)
                {
                    return Ok("Categoria removida com sucesso");
                }
                else
                {
                    return BadRequest("Houve um erro ao remover a categoria");
                }
            }
            catch
            {
                return BadRequest("Houve um erro ao remover a categoria");
            }
        }

        #endregion
    }
}
