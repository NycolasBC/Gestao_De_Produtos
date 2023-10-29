﻿using AutoMapper;
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
               .ConstructUsing(q => new Produto(q.Nome, q.Descricao, q.Ativo, q.Valor, q.DataCadastro, q.Imagem, q.QuantidadeEstoque));

            CreateMap<NovoProdutoViewModel, Produto>()
               .ConstructUsing(q => new Produto(q.Nome, q.Descricao, q.Ativo, q.Valor, q.DataCadastro, q.Imagem, q.QuantidadeEstoque));

            CreateMap<AtualizarProdutoViewModel, Produto>()
               .ConstructUsing(q => new Produto(q.Nome, q.Descricao, q.Valor, q.Imagem, q.QuantidadeEstoque));

            #endregion

            #region - Categoria

            CreateMap<CategoriaViewModel, Categoria>()
                    .ConstructUsing(c => new Categoria(c.Descricao, c.Ativo));

            CreateMap<NovaCategoriaViewModel, Categoria>()
                    .ConstructUsing(c => new Categoria(c.Descricao, c.Ativo));

            #endregion

            #region - Fornecedor

            //CreateMap<FornecedorViewModel, Fornecedor>()
            //        .ConstructUsing(f => new Fornecedor(f.Nome, f.RazaoSocial, f.CNPJ, f.Ativo, f.DataCadastro, f.EmailContato));

            //CreateMap<NovoFornecedorViewModel, Fornecedor>()
            //        .ConstructUsing(f => new Fornecedor(f.Nome, f.RazaoSocial, f.CNPJ, f.Ativo, f.DataCadastro, f.EmailContato));

            #endregion
        }
    }
}
