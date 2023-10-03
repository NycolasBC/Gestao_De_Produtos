using GestaoDeProdutos.Domain.Entities;
using GestaoDeProdutos.Domain.Interfaces;
using Microsoft.Win32;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoDeProduto.Data.Repositories
{
    public class CategoriaRepository : ICategoriaRepository
    {
        #region - Atributos e Construtor

        private readonly string _categoriaCaminhoArquivo;

        public CategoriaRepository()
        {
            _categoriaCaminhoArquivo = Path.Combine(Directory.GetCurrentDirectory(), "FileJsonData", "categoria.json");
        }

        #endregion

        #region - Funções de repositorio

        public void AdicionarCategoria(Categoria novaCategoria)
        {
            List<Categoria> categorias = LerCategoriasDoArquivo();

            int proximoCodigo = ObterProximoCodigoDisponivel();

            Categoria categoria = new Categoria()
            {
                Codigo = proximoCodigo,
                Descricao = novaCategoria.Descricao
            };

            categorias.Add(categoria);
            EscreveCategoriasNoArquivo(categorias);
        }

        public void AtualizarCategoria(Categoria categoria, int id)
        {
            List<Categoria> categorias = LerCategoriasDoArquivo();

            int index = categorias.FindIndex(c => c.Codigo == id);
            if (index != -1)
            {
                Categoria categoriaAtualizada = new Categoria()
                {
                    Codigo = categoria.Codigo,
                    Descricao = categoria.Descricao
                };

                categorias[index] = categoriaAtualizada;
                EscreveCategoriasNoArquivo(categorias);
            }
        }

        public void RemoverCategoria(int id)
        {
            List<Categoria> categorias = LerCategoriasDoArquivo();

            if (categorias.Any())
            {
                Categoria categoriaDescartada = categorias.Find(c => c.Codigo == id);
                if (categoriaDescartada != null)
                {
                    categorias.Remove(categoriaDescartada);
                    EscreveCategoriasNoArquivo(categorias);
                }
            }
        }

        public List<Categoria> ObterTodasCategorias()
        {
            List<Categoria> categorias = LerCategoriasDoArquivo();
            return categorias;
        }

        public Categoria ObterCategoriaPorId(int id)
        {
            List<Categoria> categorias = LerCategoriasDoArquivo();

            if (!categorias.Any())
            {
                return null; 
            }

            Categoria categoriaProcurada = categorias.Find(c => c.Codigo == id);
            if (categoriaProcurada == null)
            {
                return null;
            }

            return categoriaProcurada;
        }

        #endregion

        #region - Funções do arquivo
        private List<Categoria> LerCategoriasDoArquivo()
        {
            if (!System.IO.File.Exists(_categoriaCaminhoArquivo))
            {
                return new List<Categoria>();
            }

            string json = System.IO.File.ReadAllText(_categoriaCaminhoArquivo);
            return JsonConvert.DeserializeObject<List<Categoria>>(json);
        }

        private int ObterProximoCodigoDisponivel()
        {
            List<Categoria> categorias = LerCategoriasDoArquivo();
            if (categorias.Any())
            {
                return categorias.Max(p => p.Codigo) + 1;
            }
            else
            {
                return 1;
            }
        }

        private void EscreveCategoriasNoArquivo(List<Categoria> categoria)
        {
            string json = JsonConvert.SerializeObject(categoria);
            System.IO.File.WriteAllText(_categoriaCaminhoArquivo, json);
        }

        #endregion
    }
}
