//using AutoMapper;
//using GestaoDeProduto.Data.Providers.MongoDb.Collections;
//using GestaoDeProduto.Data.Providers.MongoDb.Interfaces;
//using GestaoDeProdutos.Domain.Entities;
//using GestaoDeProdutos.Domain.Interfaces;
//using Newtonsoft.Json;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace GestaoDeProduto.Data.Repositories
//{
//    public class FornecedorRepository : IFornecedorRepository
//    {
//        #region - Atributos e Construtor

//        private readonly IMongoRepository<FornecedorCollection> _fornecedorRepository;
//        private readonly IMapper _mapper;

//        public FornecedorRepository(IMongoRepository<FornecedorCollection> fornecedorRepository, IMapper mapper)
//        {
//            _fornecedorRepository = fornecedorRepository;
//            _mapper = mapper;
//        }

//        #endregion

//        #region - Funções de repositorio

//        public void AdicionarFornecedor(Fornecedor fornecedor)
//        {
//            var novoFornecedorCollection = _mapper.Map<FornecedorCollection>(fornecedor);
//            await _fornecedorRepository.InsertOneAsync(novoFornecedorCollection);
//        }

//        public void AtualizarFornecedor(Fornecedor fornecedor, int id)
//        {
//            List<Fornecedor> fornecedores = LerFornecedoresDoArquivo();

//            int index = fornecedores.FindIndex(c => c.Codigo == id);
//            if (index != -1)
//            {
//                Fornecedor fornecedorAtualizado = new Fornecedor()
//                {
//                    Codigo = id,
//                    RazaoSocial = fornecedor.RazaoSocial,
//                    CNPJ = fornecedor.CNPJ,
//                    Ativo = fornecedor.Ativo,
//                    DataCadastro = DateTime.Now,
//                    EmailContato = fornecedor.EmailContato
//                };

//                fornecedores[index] = fornecedorAtualizado;
//                EscreveFornecedoresNoArquivo(fornecedores);
//            }
//        }

//        public void RemoverFornecedor(int id)
//        {
//            List<Fornecedor> fornecedor = LerFornecedoresDoArquivo();

//            if (fornecedor.Any())
//            {
//                Fornecedor fornecedorDescartado = fornecedor.Find(c => c.Codigo == id);
//                if (fornecedorDescartado != null)
//                {
//                    fornecedor.Remove(fornecedorDescartado);
//                    EscreveFornecedoresNoArquivo(fornecedor);
//                }
//            }
//        }

//        public IList<Fornecedor> ObterTodosFornecedores()
//        {
//            var listaDeFornecedores = _fornecedorRepository.FilterBy(filtro => true);

//            return _mapper.Map<IEnumerable<Fornecedor>>(listaDeFornecedores);
//        }

//        public Fornecedor ObterFornecedorPorId(int id)
//        {
//            throw new NotImplementedException();
//        }

//        #endregion
//    }
//}
