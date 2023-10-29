using AutoMapper;
using GestaoDeProdutos.Application.ViewModels;
using GestaoDeProdutos.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoDeProdutos.Application.AutoMapper
{
    public class DomainToApplication : Profile
    {
        public DomainToApplication() 
        {
            CreateMap<Produto, ProdutoViewModel>();
            CreateMap<Produto, AtualizarProdutoViewModel>();
            CreateMap<Produto, NovoProdutoViewModel>();

            CreateMap<Categoria, CategoriaViewModel>();
            CreateMap<Categoria, NovaCategoriaViewModel>();

            //CreateMap<Fornecedor, FornecedorViewModel>();
        }
    }
}
