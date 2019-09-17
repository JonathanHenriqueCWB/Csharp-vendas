using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VendasConsole.DAL;
using VendasConsole.Models;

namespace VendasConsole.Views
{
    class ListarVendas
    {
        public static void Renderizar(List<Venda> vendas)
        {
            double subtotal, totalVenda = 0, totalGeral = 0;
            Console.WriteLine("  -- LISTAR VENDAS --  \n");
            foreach (Venda vendaCadastrada in vendas)
            {
                //VENDA
                Console.WriteLine("Data: " +
                    vendaCadastrada.CriadoEm.ToLongDateString());
                Console.WriteLine("Cliente: " + 
                    vendaCadastrada.Cliente.Nome);
                Console.WriteLine("Vendedor: " +
                    vendaCadastrada.Vendedor.Nome);
                Console.WriteLine("\n -- ITENS DA VENDA -- ");
                //ITENS DA VENDA
                foreach (ItemVenda itemCadastrado in vendaCadastrada.Produtos)
                {
                    Console.WriteLine("\t" + 
                        itemCadastrado.Produto.Nome);
                    subtotal = itemCadastrado.Quantidade * 
                        itemCadastrado.Preco;
                    Console.WriteLine("\t" + itemCadastrado.Quantidade +
                        " x " + itemCadastrado.Preco.ToString("C2") +
                        " = " + subtotal.ToString("C2"));
                    totalVenda += subtotal;
                }
                Console.WriteLine("\nTotal da venda: " + 
                    totalVenda.ToString("C2") + "\n");
                totalGeral += totalVenda;
            }
            Console.WriteLine("\nTotal geral: " +
                totalGeral.ToString("C2"));
        }
    }
}
