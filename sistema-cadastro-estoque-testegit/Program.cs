List<Produto> produtos = new List<Produto>();

produtos.Add(new Produto("Mouse", 50.0, 10));
produtos.Add(new Produto("Teclado", 150.0, 5));
produtos.Add(new Produto("Monitor", 800.0, 3));
produtos.Add(new Produto("Mousepad", 50.0, 10));

int opcao;

do
{
    Console.WriteLine("\n===== SISTEMA DE PRODUTOS =====");
    Console.WriteLine("\n1 - Cadastrar produto");
    Console.WriteLine("2 - Listar produtos");
    Console.WriteLine("3 - Mostrar quantidade de produtos");
    Console.WriteLine("4 - Adicionar estoque");
    Console.WriteLine("5 - Remover estoque");
    Console.WriteLine("0 - Sair");

    Console.Write("\nEscolha uma opção: ");
    if(!int.TryParse(Console.ReadLine(), out opcao))
{
        Console.WriteLine("Digite uma opção numérica válida!");
        opcao = -1;
        continue;
    }

    switch (opcao)
    {
        case 1:
            CadastrarProduto(produtos);
            break;
        case 2:
            ListarProdutos(produtos);
            break;
        case 3:
            MostrarQuantidade(produtos);
            break;
        case 4:
            AdicionarEstoqueProduto(produtos);
            break;
        case 5:
            RemoverEstoqueProduto(produtos);
            break;
        case 0:
            Console.WriteLine("\nSaindo do programa");
            break;
        default:
            Console.WriteLine("\nOpção inválida!");
            break;
    }
}
while (opcao != 0);

void MostrarQuantidade(List<Produto> listaProdutos)
{
    Console.WriteLine($"\nProdutos cadastrados: {listaProdutos.Count}");
}

void ListarProdutos(List<Produto> listaProdutos)
{
    if (listaProdutos.Count == 0)
    {
        Console.WriteLine("\nNenhum produto cadastrado.");
    }
    else
    {
        foreach (Produto produto in listaProdutos)
        {
            produto.ExibirInformacoes();
        }
    }
}
void CadastrarProduto(List<Produto> listaProdutos)
{
    string? nomeProduto;
    bool nomeValido = false;
    do
    {
        Console.Write("Cadastrar nome do produto: ");
        nomeProduto = Console.ReadLine()?.Trim();
        if (string.IsNullOrWhiteSpace(nomeProduto))
        {
            Console.WriteLine("Nome inválido! Tente novamente.");
        }
        else
        {
            bool produtoExistente = false;

            foreach (Produto produto in listaProdutos)
            {
                if (string.Equals(produto.Nome, nomeProduto, StringComparison.OrdinalIgnoreCase))
                {
                    produtoExistente = true;
                    break;
                }
            }

            if (produtoExistente)
            {
                Console.WriteLine("Produto já cadastrado! Tente outro nome.");
                continue;
            }
            nomeValido = true;
            double precoProduto;
            bool precoValido = false;

            do
            {
                Console.Write("Cadastrar preço: ");

                if (double.TryParse(Console.ReadLine(), out precoProduto) && precoProduto >= 0)
                {
                    precoValido = true;
                    int quantidadeProduto;
                    bool quantidadeValida = false;

                    do
                    {
                        Console.Write("Cadastrar quantidade: ");

                        if (int.TryParse(Console.ReadLine(), out quantidadeProduto) && quantidadeProduto >= 0)
                        {
                            quantidadeValida = true;
                            listaProdutos.Add(new Produto(nomeProduto, precoProduto, quantidadeProduto));
                            Console.WriteLine("\nProduto cadastrado com sucesso!");
                        }
                        else
                        {
                            Console.WriteLine("Quantidade inválida! Tente novamente.");
                        }

                    } while (!quantidadeValida);
                }
                else
                {
                    Console.WriteLine("Preço inválido! Tente novamente.");
                }

            } while (!precoValido);
        }
    } while (!nomeValido);
}

void AdicionarEstoqueProduto(List<Produto> listaProdutos)
{
    if (listaProdutos.Count == 0)
    {
        Console.WriteLine("\nNenhum produto cadastrado!");
        return;
    }

    string? nomeBusca;
    bool nomeEncontrado = false;
    do
    {
        Console.Write("\nDigite o nome do produto: ");
        nomeBusca = Console.ReadLine()?.Trim();

        if (string.IsNullOrWhiteSpace(nomeBusca))
        {
            Console.WriteLine("Nome inválido! Tente novamente.");
        }
        else
        {
            foreach (Produto produto in listaProdutos)
            {
                if (string.Equals(produto.Nome, nomeBusca, StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine("Produto encontrado!");
                    nomeEncontrado = true;

                    int quantidadeAdicionar;
                    bool quantidadeValida = false;
                    do
                    {
                        Console.Write("\nDigite a quantidade a ser adicionada: ");
                        if (int.TryParse(Console.ReadLine(), out quantidadeAdicionar) && quantidadeAdicionar > 0)
                        {
                            produto.AdicionarEstoque(quantidadeAdicionar);
                            Console.WriteLine("Estoque atualizado com sucesso!");
                            quantidadeValida = true;
                        }
                        else
                        {
                            Console.WriteLine("Quantidade inválida! Tente novamente.");
                        }
                    } while (!quantidadeValida);
                    break;
                }
            }
            if (!nomeEncontrado)
            {
                Console.WriteLine("Produto não encontrado! Tente novamente.");
            }
        }
    } while (!nomeEncontrado);
}

void RemoverEstoqueProduto(List<Produto> listaProdutos)
{
    if (listaProdutos.Count == 0)
    {
        Console.WriteLine("\nNenhum produto cadastrado!");
        return;
    }

    string? nomeBusca;
    bool nomeEncontrado = false;
    do
    {
        Console.Write("\nDigite o nome do produto: ");
        nomeBusca = Console.ReadLine()?.Trim();

        if (string.IsNullOrWhiteSpace(nomeBusca))
        {
            Console.WriteLine("Nome inválido! Tente novamente.");
        }
        else
        {
            foreach (Produto produto in listaProdutos)
            {
                if (string.Equals(produto.Nome, nomeBusca, StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine("Produto encontrado!");
                    nomeEncontrado = true;

                    int quantidadeRemover;
                    bool quantidadeValida = false;
                    do
                    {
                        Console.Write("\nDigite a quantidade a ser removida: ");
                        if (int.TryParse(Console.ReadLine(), out quantidadeRemover) && quantidadeRemover > 0)
                        {
                            if (quantidadeRemover > produto.Quantidade)
                            {
                                Console.WriteLine("Estoque insuficiente! Tente novamente.");
                            }
                            else
                            {
                                produto.RemoverEstoque(quantidadeRemover);
                                Console.WriteLine("Estoque atualizado com sucesso!");
                                quantidadeValida = true;
                            }
                        }
                        else
                        {
                            Console.WriteLine("Quantidade inválida! Tente novamente.");
                        }
                    } while (!quantidadeValida);
                    break;
                }
            }
            if (!nomeEncontrado)
            {
                Console.WriteLine("Produto não encontrado! Tente novamente.");
            }
        }
    } while (!nomeEncontrado);
}