using System;

public class GameLoop
{
    private GameState estadoAtual;

    private Player player;
    private Inventory inventory;
    private StoryGraph story;
    private ConsoleUI ui;

    private Scene cenaAtual;

    public GameLoop()
    {
        estadoAtual = GameState.Menu;

        player = new Player();
        inventory = new Inventory();
        story = new StoryGraph();
        ui = new ConsoleUI();

        cenaAtual = story.Cenas["entrada"];
    }

    public void Run()
    {
        bool executando = true;

        while (executando)
        {
            switch (estadoAtual)
            {
                case GameState.Menu:
                    Menu();
                    break;

                case GameState.Playing:
                    Playing();
                    break;

                case GameState.Inventory:
                    InventoryMenu();
                    break;

                case GameState.Options:
                    Options();
                    break;

                case GameState.GameOver:
                    GameOver();
                    executando = false;
                    break;

                case GameState.Victory:
                    Victory();
                    executando = false;
                    break;
            }
        }
    }

    private void Menu()
    {
        Console.Clear();

        Console.WriteLine("================================");
        Console.WriteLine("       O LEGADO DO FARAÓ");
        Console.WriteLine("================================");
        Console.WriteLine();

        Console.WriteLine("1 - Iniciar aventura");
        Console.WriteLine("2 - Opções");
        Console.WriteLine("3 - Sair");

        string escolha = Console.ReadLine() ?? "";

        switch (escolha)
        {
            case "1":
                estadoAtual = GameState.Playing;
                break;

            case "2":
                estadoAtual = GameState.Options;
                break;

            case "3":
                Environment.Exit(0);
                break;
        }
    }

    private void Playing()
    {
        Console.Clear();

        ui.MostrarCena(cenaAtual);
        ui.MostrarStatus(player);

        Console.WriteLine();

        for (int i = 0; i < cenaAtual.Escolhas.Count; i++)
        {
            Console.WriteLine(
                $"{i + 1} - {cenaAtual.Escolhas[i].Texto}"
            );
        }

        Console.WriteLine();
        Console.WriteLine("I - Inventário");

        string entrada = Console.ReadLine() ?? "";

        if (entrada.ToUpper() == "I")
        {
            estadoAtual = GameState.Inventory;
            return;
        }

        if (!int.TryParse(entrada, out int escolha))
        {
            return;
        }

        if (escolha < 1 || escolha > cenaAtual.Escolhas.Count)
        {
            return;
        }

        Choice escolhaSelecionada =
            cenaAtual.Escolhas[escolha - 1];

        if (!string.IsNullOrEmpty(escolhaSelecionada.ItemNecessario))
        {
            if (!inventory.Possui(escolhaSelecionada.ItemNecessario))
            {
                Console.WriteLine();
                Console.WriteLine(
                    $"Você precisa de: {escolhaSelecionada.ItemNecessario}"
                );

                Console.ReadKey();
                return;
            }
        }

        ProcessarEscolha(escolhaSelecionada);
    }

    private void ProcessarEscolha(Choice escolha)
    {
        player.Bateria -= 5;
        player.Sanidade -= 3;

        if (player.Bateria <= 0)
        {
            player.Bateria = 0;
            estadoAtual = GameState.GameOver;
            return;
        }

        if (player.Sanidade <= 0)
        {
            player.Sanidade = 0;
            estadoAtual = GameState.GameOver;
            return;
        }

        if (escolha.ProximaCena == "VITORIA")
        {
            estadoAtual = GameState.Victory;
            return;
        }

        if (escolha.ProximaCena == "SACRIFICIO")
        {
            estadoAtual = GameState.Victory;
            return;
        }

        if (escolha.ProximaCena == "DERROTA")
        {
            estadoAtual = GameState.GameOver;
            return;
        }

        cenaAtual = story.Cenas[escolha.ProximaCena];

        VerificarItens();
    }

    private void VerificarItens()
    {
        if (cenaAtual.Id == "biblioteca" &&
            !inventory.Possui("Mago Negro"))
        {
            Console.WriteLine();
            Console.WriteLine(
                "Entre os antigos papiros, você encontra uma carta lendária!"
            );

            inventory.Adicionar("Mago Negro");

            Console.WriteLine();
            Console.WriteLine("ITEM OBTIDO: Mago Negro");

            Console.ReadKey();
        }

        if (cenaAtual.Id == "tesouro" &&
            !inventory.Possui("Dragão Branco de Olhos Azuis"))
        {
            Console.WriteLine();
            Console.WriteLine(
                "Dentro da caixa dourada existe uma carta extremamente poderosa!"
            );

            inventory.Adicionar("Dragão Branco de Olhos Azuis");

            Console.WriteLine();
            Console.WriteLine(
                "ITEM OBTIDO: Dragão Branco de Olhos Azuis"
            );

            Console.ReadKey();
        }
    }

    private void InventoryMenu()
    {
        Console.Clear();

        inventory.Mostrar();

        ConsoleKey tecla = Console.ReadKey(true).Key;

        if (tecla == ConsoleKey.Escape)
        {
            estadoAtual = GameState.Playing;
        }
    }

    private void GameOver()
    {
        Console.Clear();

        Console.WriteLine("================================");
        Console.WriteLine("          GAME OVER");
        Console.WriteLine("================================");
        Console.WriteLine();

        Console.WriteLine(
            "A maldição da tumba venceu."
        );

        Console.WriteLine();
        Console.WriteLine("Pressione qualquer tecla...");

        Console.ReadKey();
    }

    private void Victory()
    {
        Console.Clear();

        Console.WriteLine("================================");
        Console.WriteLine("          VITÓRIA!");
        Console.WriteLine("================================");
        Console.WriteLine();

        Console.WriteLine(
            "Você escapou da tumba carregando "
            + "as lendárias cartas mágicas."
        );

        Console.WriteLine();
        Console.WriteLine(
            "Talvez os antigos egípcios realmente "
            + "tenham inventado o primeiro card game."
        );

        Console.WriteLine();
        Console.WriteLine("Pressione qualquer tecla...");

        Console.ReadKey();
    }

    private void Options()
    {
        Console.Clear();

        Console.WriteLine("========== OPÇÕES ==========");
        Console.WriteLine();
        Console.WriteLine("Nada para configurar ainda.");
        Console.WriteLine();
        Console.WriteLine("Pressione ESC para voltar.");

        ConsoleKey tecla = Console.ReadKey(true).Key;

        if (tecla == ConsoleKey.Escape)
        {
            estadoAtual = GameState.Menu;
        }
    }
}