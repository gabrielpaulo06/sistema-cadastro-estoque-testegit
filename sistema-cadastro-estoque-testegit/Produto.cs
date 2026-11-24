class Produto
{
    public string Nome { get; set; }
    public double Preco { get; set; }
    public int Quantidade { get; private set; }

    public Produto(string nomeProduto, double precoProduto, int quantidadeProduto)
    {
        Nome = nomeProduto;
        Preco = precoProduto;
        Quantidade = quantidadeProduto;
    }
    public void ExibirInformacoes()
    {
        Console.WriteLine($"\nNome: {Nome}");
        Console.WriteLine($"Preço: {Preco:C2}");
        Console.WriteLine($"Quantidade: {Quantidade}");
    }
    public void AdicionarEstoque(int quantidadeProduto)
    {
        if (quantidadeProduto <= 0)
        {
            Console.WriteLine("Quantidade inválida!");
        }
        else
        {
            Quantidade += quantidadeProduto;
            Console.WriteLine($"\n{quantidadeProduto} unidades adicionadas ao estoque.");
        }
    }
    public void RemoverEstoque(int quantidadeProduto)
    {
        if (quantidadeProduto <= 0)
        {
            Console.WriteLine("Quantidade inválida!");
        }
        else if (quantidadeProduto > Quantidade)
        {
            Console.WriteLine("Estoque insuficiente!");
        }
        else
        {
            Quantidade -= quantidadeProduto;
            Console.WriteLine($"\n{quantidadeProduto} unidades removidas do estoque.");
        }
    }
}