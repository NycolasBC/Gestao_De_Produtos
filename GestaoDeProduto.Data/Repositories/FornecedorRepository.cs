using GestaoDeProdutos.Domain.Entities;
using GestaoDeProdutos.Domain.Interfaces;
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
            fornecedores.Add(fornecedor);
            EscreveFornecedoresNoArquivo(fornecedores);
        }

        public void AtualizarFornecedor(Fornecedor categoria)
        {
            throw new NotImplementedException();
        }

        public void RemoverFornecedor(Fornecedor categoria)
        {
            throw new NotImplementedException();
        }

        public IList<Fornecedor> ObterTodosFornecedores()
        {
            throw new NotImplementedException();
        }

        public Fornecedor ObterFornecedorPorId(int id)
        {
            throw new NotImplementedException();
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

        private void EscreveFornecedoresNoArquivo(Fornecedor fornecedor)
        {
            string json = JsonConvert.SerializeObject(fornecedor);
            System.IO.File.WriteAllText(_fornecedorCaminhoArquivo, json);
        }

        #endregion
    }
}
