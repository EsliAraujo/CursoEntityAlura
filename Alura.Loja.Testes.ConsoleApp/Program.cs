using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alura.Loja.Testes.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            //GravarUsandoAdoNet();
            //GravarUsandoEntity();
            //RecuperarProdutos();
            //ExcluirProdutos();
            //RecuperarProdutos();
            AtualizarProduto();
        }

        private static void AtualizarProduto()
        {
            //incluir o produto
            GravarUsandoEntity();
            RecuperarProdutos();

            //atualizar o produto
            using (var contexto = new ProdutoDAOentity())
            {
                Produto primeiro = contexto.Produtos().First();
                primeiro.Nome = "Cassino Royale II";
                contexto.Atualizar(primeiro);
            }
            RecuperarProdutos();
        }

        private static void ExcluirProdutos()
        {
            using (var contexto = new ProdutoDAOentity())
            {
                IList<Produto> produtos = contexto.Produtos();
                foreach (var item in produtos)
                {
                    contexto.Remover(item);                   
                }
            }
        }

        public static void RecuperarProdutos()
        {
            using (var contexto = new ProdutoDAOentity())
            {
                IList<Produto> produtos = contexto.Produtos();
                Console.WriteLine("Foram encontrados {0} prudutos da consulta", produtos.Count);
                foreach (var item in produtos)
                {
                    Console.WriteLine(item.Nome);
                }
            }
        }

        public static void GravarUsandoEntity()
        {
            Produto p = new Produto();
            p.Nome = "Cassino Royale";
            p.Categoria = "Filmes";
            p.Preco = 19.89;

            using (var contexto = new ProdutoDAOentity())
            {
                contexto.Adicionar(p);
            }
        }

        private static void GravarUsandoAdoNet()
        {
            Produto p = new Produto();
            p.Nome = "Harry Potter e a Ordem da Fênix";
            p.Categoria = "Livros";
            p.Preco = 19.89;

            using (var repo = new ProdutoDAO())
            {
                repo.Adicionar(p);
            }
        }
    }
}
