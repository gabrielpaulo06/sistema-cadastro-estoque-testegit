class Produto
{
    public string Nome { get; set; }
    public double Preco { get; set; }
    public int Quantidade { get; set; }

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
        Quantidade += quantidadeProduto;
        Console.WriteLine($"\n{quantidadeProduto} unidades adicionadas ao estoque.");
    }
}
