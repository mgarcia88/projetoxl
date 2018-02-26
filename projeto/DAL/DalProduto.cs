using projeto.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace projeto.DAL
{
    public class DalProduto
    {
        Conexao conexao;

        public DalProduto()
        {
            conexao = new Conexao();
        }
        public void insereProduto(Produtos prod)
        {
            string _sql = "";
            _sql = "insert into tb_produtos (pro_nome, pro_valor, pro_quantidade,  pro_unidade) values ('" + prod.NomeProduto + "'," + prod.Valor.ToString().Replace(",",".") + "," + prod.Quantidade + ",'" + prod.Unidade + "')";

            conexao.executarInsertUpdate(_sql);

        }

        public void atualizaProduto(Produtos prod)
        {
            string _sql = "";
            _sql = "update tb_produtos set pro_valor = " + prod.Valor + ", pro_quantidade = " + prod.Quantidade + ",  pro_unidade = '" + prod.Unidade + "' where pro_id = " + prod.ID;

            conexao.executarInsertUpdate(_sql);

        }


        public int verificaProdutoExiste(string nomeProduto)
        {
            string _sql = "";
            int codigoProduto = 0;
            _sql = "select pro_id from tb_produtos where pro_nome = '" + nomeProduto + "'";

            codigoProduto = int.Parse(conexao.executaSelectScalar(_sql).ToString());
            return codigoProduto;

        }

        public List<Produtos> SelecionarProdutos(string nomeProduto)
        {
            string _query = string.Empty;

            if (string.IsNullOrEmpty(nomeProduto))
                _query = "select * from tb_produtos";
            else
                _query = "select  * from tb_produtos where pro_nome like '%"+nomeProduto+"%'";

            DataTable dtRetorno = new DataTable();
            dtRetorno = conexao.ExecutaConsulta(_query);
            List<Produtos> listaProdutos = new List<Produtos>();

            foreach (DataRow dr in dtRetorno.Rows)
            {
                listaProdutos.Add(
                    new Produtos
                    {
                        ID = Convert.ToInt32(dr["pro_id"]),
                        NomeProduto = Convert.ToString(dr["pro_nome"]),
                        Quantidade = Convert.ToInt32(dr["pro_quantidade"]),
                        Unidade = Convert.ToString(dr["pro_unidade"]),
                        Valor = Convert.ToDecimal(dr["pro_valor"]),                        
                        ValorTotal = (Convert.ToInt32(dr["pro_quantidade"]) *  Convert.ToDecimal(dr["pro_valor"]))
                    });
            }
            return listaProdutos;

        }
    }
}