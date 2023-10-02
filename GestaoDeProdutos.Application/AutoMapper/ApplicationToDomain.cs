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
    public class ApplicationToDomain : Profile
    {
        public ApplicationToDomain() 
        {
            CreateMap<ProdutoViewModel, Produto>()
                    .ConstructUsing(p => new Produto(p.Codigo, p.Nome, p.Estoque, p.Valor, p.Ativo, p.DataCadastro));

            CreateMap<NovoProdutoViewModel, Produto>()
                    .ConstructUsing(p => new Produto(p.Nome, p.Estoque, p.Valor, p.Ativo, p.DataCadastro));
        }
    }
}
