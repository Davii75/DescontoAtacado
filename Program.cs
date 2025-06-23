class Produto
{
    public string GTIN = string.Empty;
    public string Descricao = string.Empty;
    public decimal PrecoVarejo;
    public decimal? PrecoAtacado;
    public int? UnidadesAtacado;
}

class LeituraCaixa
{
    public string GTIN = string.Empty;
    public int Quantidade;
}

class Program
{
    static void Main()
    {
        var produtos = new Dictionary<string, Produto>
        {
            ["7891024110348"] = new Produto { GTIN = "7891024110348", Descricao = "SABONETE OLEO DE ARGAN", PrecoVarejo = 2.88m, PrecoAtacado = 2.51m, UnidadesAtacado = 12 },
            ["7891048038017"] = new Produto { GTIN = "7891048038017", Descricao = "CHÁ DE CAMOMILA", PrecoVarejo = 4.40m, PrecoAtacado = 4.37m, UnidadesAtacado = 3 },
            ["7896066334509"] = new Produto { GTIN = "7896066334509", Descricao = "TORRADA WICKBOLD", PrecoVarejo = 5.19m },
            ["7891700203142"] = new Produto { GTIN = "7891700203142", Descricao = "BEBIDA DE SOJA ADES", PrecoVarejo = 2.39m, PrecoAtacado = 2.38m, UnidadesAtacado = 6 },
            ["7894321711263"] = new Produto { GTIN = "7894321711263", Descricao = "TODDY", PrecoVarejo = 9.79m },
            ["7896001250611"] = new Produto { GTIN = "7896001250611", Descricao = "ADOÇANTE LINEA", PrecoVarejo = 9.89m, PrecoAtacado = 9.10m, UnidadesAtacado = 10 },
            ["7793306013029"] = new Produto { GTIN = "7793306013029", Descricao = "CEREAL SUCRILHOS", PrecoVarejo = 12.79m, PrecoAtacado = 12.35m, UnidadesAtacado = 3 },
            ["7896004400914"] = new Produto { GTIN = "7896004400914", Descricao = "COCO RALADO", PrecoVarejo = 4.20m, PrecoAtacado = 4.05m, UnidadesAtacado = 6 },
            ["7898080640017"] = new Produto { GTIN = "7898080640017", Descricao = "LEITE ITALAC", PrecoVarejo = 6.99m, PrecoAtacado = 6.89m, UnidadesAtacado = 12 },
            ["7891025301516"] = new Produto { GTIN = "7891025301516", Descricao = "DANONINHO", PrecoVarejo = 12.99m },
            ["7891030003115"] = new Produto { GTIN = "7891030003115", Descricao = "CREME DE LEITE MOCOCA", PrecoVarejo = 3.12m, PrecoAtacado = 3.09m, UnidadesAtacado = 4 }
        };

        var leituras = new List<LeituraCaixa>
        {
            new LeituraCaixa { GTIN = "7891048038017", Quantidade = 1 },
            new LeituraCaixa { GTIN = "7896004400914", Quantidade = 4 },
            new LeituraCaixa { GTIN = "7891030003115", Quantidade = 1 },
            new LeituraCaixa { GTIN = "7891024110348", Quantidade = 6 },
            new LeituraCaixa { GTIN = "7898080640017", Quantidade = 24 },
            new LeituraCaixa { GTIN = "7896004400914", Quantidade = 8 },
            new LeituraCaixa { GTIN = "7891700203142", Quantidade = 8 },
            new LeituraCaixa { GTIN = "7891048038017", Quantidade = 1 },
            new LeituraCaixa { GTIN = "7793306013029", Quantidade = 3 },
            new LeituraCaixa { GTIN = "7896066334509", Quantidade = 2 },
        };

        var totalPorProduto = new Dictionary<string, int>();
        foreach (var item in leituras)
        {
            if (!totalPorProduto.ContainsKey(item.GTIN))
            totalPorProduto[item.GTIN] = 0;
            totalPorProduto[item.GTIN] += item.Quantidade;
        }

        decimal subtotal = 0;
        decimal totalDescontos = 0;
        var descontosIndividuais = new Dictionary<string, decimal>();

        foreach (var kv in totalPorProduto)
        {
            string gtin = kv.Key;
            int quantidade = kv.Value;
            Produto produto = produtos[gtin];

            if (produto.PrecoAtacado.HasValue && produto.UnidadesAtacado.HasValue && quantidade >= produto.UnidadesAtacado.Value)
            {
                int pacotes = quantidade / produto.UnidadesAtacado.Value;
                int resto = quantidade % produto.UnidadesAtacado.Value;

                decimal precoNormal = produto.PrecoVarejo * quantidade;
                decimal precoComDesconto = pacotes * produto.UnidadesAtacado.Value * produto.PrecoAtacado.Value + resto * produto.PrecoVarejo;
                decimal desconto = precoNormal - precoComDesconto;

                if (desconto > 0)
                    descontosIndividuais[gtin] = desconto;

                subtotal += precoComDesconto;
                totalDescontos += desconto;
            }
            else
            {
                subtotal += produto.PrecoVarejo * quantidade;
            }
        }

        decimal totalFinal = subtotal;

        Console.WriteLine("\n--- Desconto no Atacado ---\n");
        Console.WriteLine("Descontos:");
        foreach (var d in descontosIndividuais)
        {
            Console.WriteLine($"{d.Key,-18} R$ {d.Value:F2}");
        }

        Console.WriteLine();
        Console.WriteLine($"(+) Subtotal  =    R$ {subtotal + totalDescontos:C2}");
        Console.WriteLine($"(-) Descontos =      R$ {totalDescontos:C2}");
        Console.WriteLine($"(=) Total     =    R$ {totalFinal:C2}");
    }
}
