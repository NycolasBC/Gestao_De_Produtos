using GestaoDeProdutos.Domain.Entities;
using GestaoDeProdutos.Domain.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoDeProduto.Data.Repositories
{
    public class FornecedorRepository : IFornecedorRepository
    {
        #region - Atributos e Construtor

        private readonly string _fornecedorCaminhoArquivo;

        public FornecedorRepository()
        {
            _fornecedorCaminhoArquivo = Path.Combine(Directory.GetCurrentDirectory(), "FileJsonData", "fornecedor.json");
        }

        #endregion

        #region - Funções de repositorio

        public void AdicionarFornecedor(Fornecedor fornecedor)
        {
            List<Fornecedor> fornecedores = new List<Fornecedor>();
            int proximoCodigo = ObterProximoCodigoDisponivel();

            Fornecedor fornecedorAtualizado = new Fornecedor()
            {
                Codigo = proximoCodigo,
                RazaoSocial = fornecedor.RazaoSocial,
                CNPJ = fornecedor.CNPJ,
                Ativo = fornecedor.Ativo,
                DataCadastro = DateTime.Now,
                EmailContato = fornecedor.EmailContato
            };

            fornecedores.Add(fornecedorAtualizado);
            EscreveFornecedoresNoArquivo(fornecedores);
        }

        public void AtualizarFornecedor(Fornecedor fornecedor, int id)
        {
            List<Fornecedor> fornecedores = LerFornecedoresDoArquivo();

            int index = fornecedores.FindIndex(c => c.Codigo == id);
            if (index != -1)
            {
                Fornecedor fornecedorAtualizado = new Fornecedor()
                {
                    Codigo = id,
                    RazaoSocial = fornecedor.RazaoSocial,
                    CNPJ = fornecedor.CNPJ,
                    Ativo = fornecedor.Ativo,
                    DataCadastro = DateTime.Now,
                    EmailContato = fornecedor.EmailContato
                };

                fornecedores[index] = fornecedorAtualizado;
                EscreveFornecedoresNoArquivo(fornecedores);
            }
        }

        public void RemoverFornecedor(int id)
        {
            List<Fornecedor> fornecedor = LerFornecedoresDoArquivo();

            if (fornecedor.Any())
            {
                Fornecedor fornecedorDescartado = fornecedor.Find(c => c.Codigo == id);
                if (fornecedorDescartado != null)
                {
                    fornecedor.Remove(fornecedorDescartado);
                    EscreveFornecedoresNoArquivo(fornecedor);
                }
            }
        }

        public IList<Fornecedor> ObterTodosFornecedores()
        {
            List<Fornecedor> fornecedores = LerFornecedoresDoArquivo();
            return fornecedores;
        }

        public Fornecedor ObterFornecedorPorId(int id)
        {
            List<Fornecedor> fornecedores = LerFornecedoresDoArquivo();

            if (!fornecedores.Any())
            {
                return null;
            }

            Fornecedor fornecedorProcurado = fornecedores.Find(c => c.Codigo == id);
            if (fornecedorProcurado == null)
            {
                return null;
            }

            return fornecedorProcurado;
        }

        #endregion

        #region - Funções do arquivo
        private List<Fornecedor> LerFornecedoresDoArquivo()
        {
            if (!System.IO.File.Exists(_fornecedorCaminhoArquivo))
            {
                return new List<Fornecedor>();
            }

            string json = System.IO.File.ReadAllText(_fornecedorCaminhoArquivo);
            return JsonConvert.DeserializeObject<List<Fornecedor>>(json);
        }

        private int ObterProximoCodigoDisponivel()
        {
            List<Fornecedor> fornecedores = LerFornecedoresDoArquivo();
            if (fornecedores.Any())
            {
                return fornecedores.Max(p => p.Codigo) + 1;
            }
            else
            {
                return 1;
            }
        }

        private void EscreveFornecedoresNoArquivo(List<Fornecedor> fornecedor)
        {
            string json = JsonConvert.SerializeObject(fornecedor);
            System.IO.File.WriteAllText(_fornecedorCaminhoArquivo, json);
        }

        #endregion
    }
}
