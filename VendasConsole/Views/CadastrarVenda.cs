using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VendasConsole.DAL;
using VendasConsole.Models;
using VendasConsole.Utils;

namespace VendasConsole.Views
{
    class CadastrarVenda
    {
        public static void Renderizar()
        {
            Venda venda = new Venda();
            Cliente c = new Cliente();
            Vendedor v = new Vendedor();
            Produto p = new Produto();
            ItemVenda iv = new ItemVenda();

            Console.WriteLine("  -- CADASTRAR VENDA --  \n");
            Console.WriteLine("Digite o CPF do cliente:");
            c.Cpf = Console.ReadLine();
            c = ClienteDAO.BuscarClientePorCpf(c);
            if(c != null)
            {
                venda.Cliente = c;
                Console.WriteLine("Digite o CPF do vendedor:");
                v.Cpf = Console.ReadLine();
                v = VendedorDAO.BuscarVendedorPorCpf(v);
                if(v != null)
                {
                    venda.Vendedor = v;
                    do
                    {
                        p = new Produto();
                        iv = new ItemVenda();
                        Console.Clear();
                        Console.WriteLine("  -- ADICIONAR PRODUTOS --  \n");
                        Console.WriteLine("Digite o nome do produto:");
                        p.Nome = Console.ReadLine();
                        p = ProdutoDAO.BuscarProdutoPorNome(p);
                        if (p != null)
                        {
                            iv.Produto = p;
                            iv.Preco = p.Preco;
                            Console.WriteLine("Digite a quantidade do produto:");
                            iv.Quantidade = Convert.ToInt32(Console.ReadLine());
                            venda.Produtos.Add(iv);
                            Console.WriteLine("Produto adicionado dentro da venda!");
                        }
                        else
                        {
                            Console.WriteLine("Esse produto não existe!");
                        }
                        Console.WriteLine("\nDeseja adicionar mais um produto? S|N");
                    } while (Console.ReadLine().ToUpper().Equals("S"));
                    VendaDAO.CadastrarVenda(venda);
                    Console.WriteLine("Venda cadastrada!");
                }
                else
                {
                    Console.WriteLine("Esse vendedor não existe!");
                }
            }
            else
            {
                Console.WriteLine("Esse cliente não existe!");
            }
        }
    }
}
