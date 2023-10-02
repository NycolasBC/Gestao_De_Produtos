using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoDeProdutos.Domain.Entities
{
    public class Categoria
    {
        #region Propriedades

        public int Codigo { get; private set; }
        public string Descricao { get; private set; }

        #endregion

        #region Construtores

        public Categoria(int codigo, string descricao)
        {
            Codigo = codigo;
            Descricao = descricao;
        }

        #endregion
    }
}
