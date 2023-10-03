using GestaoDeProdutos.Application.Interfaces;
using GestaoDeProdutos.Application.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace GestaoDeProdutos.WebApi.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class FornecedorController : ControllerBase
    {
        #region - Propriedades e Construtores

        private readonly IFornecedorService _fornecedorService;

        public FornecedorController(IFornecedorService fornecedorService)
        {
            _fornecedorService = fornecedorService;
        }

        #endregion

        #region - CRUD

        [HttpGet(Name = "BuscarFornecedores")]
        public IActionResult Get()
        {
            try
            {
                return Ok(_fornecedorService.ObterTodosFornecedores());
            }
            catch
            {
                return BadRequest("Nenhum fornecedor salva");
            }
        }


        [HttpGet("{id}", Name = "BuscarFornecedoresPorId")]
        public IActionResult Get(int id)
        {
            try
            {
                return Ok(_fornecedorService.ObterFornecedorPorId(id));
            }
            catch
            {
                return BadRequest("Nenhuma categoria salva");
            }
        }


        [HttpPost(Name = "AdicionarFornecedor")]
        public IActionResult Post([FromBody] NovoFornecedorViewModel novoFornecedorViewModel)
        {
            try
            {
                var adicionadoComSucesso = _fornecedorService.AdicionarFornecedor(novoFornecedorViewModel);

                if (adicionadoComSucesso)
                {
                    return Ok("Fornecedor cadastrado com sucesso");
                }
                else
                {
                    return BadRequest("Houve um erro ao cadastrar o fornecedor");
                }
            }
            catch
            {
                return BadRequest("Houve um erro ao cadastrar o fornecedor");
            }

        }


        [HttpPut("{id}", Name = "AtualizarFornecedor")]
        public IActionResult Put([FromBody] FornecedorViewModel fornecedorAtualizado, int id)
        {
            try
            {
                var atualizadoComSucesso = _fornecedorService.AtualizarFornecedor(fornecedorAtualizado, id);

                if (atualizadoComSucesso)
                {
                    return Ok("Fornecedor atualizado com sucesso");
                }
                else
                {
                    return BadRequest("Houve um erro ao atualizar o fornecedor");
                }
            }
            catch
            {
                return BadRequest("Houve um erro ao atualizar o fornecedor");
            }
        }


        [HttpDelete("{id}", Name = "RemoverFornecedor")]
        public IActionResult Delete(int id)
        {
            try
            {
                var removidoComSucesso = _fornecedorService.RemoverFornecedor(id);

                if (removidoComSucesso)
                {
                    return Ok("Fornecedor removido com sucesso");
                }
                else
                {
                    return BadRequest("Houve um erro ao remover o fornecedor");
                }
            }
            catch
            {
                return BadRequest("Houve um erro ao remover o fornecedor");
            }
        }

        #endregion
    }
}
