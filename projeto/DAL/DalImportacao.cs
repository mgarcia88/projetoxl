using projeto.DAL;
using projeto.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projeto.core.DAL
{
    public class DalImportacao
    {
        private string _sql;
        private Conexao conn;

        public string SQL { get; set; }

        public void insereImportacao(InfImportacao imp)
        {
            conn = new Conexao();
            _sql = "insert into tb_importacao (imp_arquivo, imp_data_inicio) values ('" + imp.NomeArquivo + "',getdate())";
    
            conn.executarInsertUpdate(_sql);

        }

        public bool verificaImportacaoJaExiste(string nomeArquivo)
        {
            bool jaExiste = false;
            conn = new Conexao();
            _sql = "select count(*) as total from tb_importacao where imp_arquivo = '" + nomeArquivo+"'";
           
            if (conn.executaSelectScalar(_sql) > 0)
            {
                jaExiste = true;
            }

            return jaExiste;

        }
    }
}
