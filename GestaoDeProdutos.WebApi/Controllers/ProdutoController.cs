using GestaoDeProdutos.Application.Interfaces;
using GestaoDeProdutos.Application.ViewModels;
using GestaoDeProdutos.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace GestaoDeProdutos.WebApi.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class ProdutoController : ControllerBase
    {
        private readonly IProdutoService _produtoService;

        public ProdutoController(IProdutoService produtoService)
        {
            _produtoService = produtoService;
        }

        [HttpPost(Name = "AdicionarProduto")]
        public IActionResult Post(NovoProdutoViewModel novoProdutoViewModel)
        {
            _produtoService.AdicionarProduto(novoProdutoViewModel);

            return Ok();
        }
    }
}
