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
            #region - Produto

            CreateMap<ProdutoViewModel, Produto>()
                    .ConstructUsing(p => new Produto(p.Codigo, p.Nome, p.Estoque, p.Valor, p.Ativo, p.DataCadastro));

            CreateMap<NovoProdutoViewModel, Produto>()
                    .ConstructUsing(p => new Produto(p.Codigo, p.Nome, p.Estoque, p.Valor, p.Ativo, p.DataCadastro));

            #endregion

            #region - Categoria

            CreateMap<CategoriaViewModel, Categoria>()
                    .ConstructUsing(c => new Categoria(c.Codigo, c.Descricao));

            CreateMap<NovaCategoriaViewModel, Categoria>()
                    .ConstructUsing(c => new Categoria(c.Codigo, c.Descricao));

            #endregion

            #region - Fornecedor

            CreateMap<FornecedorViewModel, Fornecedor>()
                    .ConstructUsing(f => new Fornecedor(f.Codigo, f.RazaoSocial, f.CNPJ, f.Ativo, f.DataCadastro, f.EmailContato));

            CreateMap<NovoFornecedorViewModel, Fornecedor>()
                    .ConstructUsing(f => new Fornecedor(f.Codigo, f.RazaoSocial, f.CNPJ, f.Ativo, f.DataCadastro, f.EmailContato));

            #endregion
        }
    }
}
