public class ConsoleUI
{
    public void LimparTela()
    {
        Console.Clear();
    }

    public void MostrarStatus(Player player)
    {
        Console.WriteLine("--------------------------------");
        Console.WriteLine($"❤️ Vida: {player.Vida}");
        Console.WriteLine($"🔋 Bateria: {player.Bateria}");
        Console.WriteLine($"🧠 Sanidade: {player.Sanidade}");
        Console.WriteLine("--------------------------------");
    }

    public void MostrarCena(Scene cena)
    {
        Console.WriteLine();
        Console.WriteLine("================================");
        Console.WriteLine(cena.Titulo);
        Console.WriteLine("================================");
        Console.WriteLine();
        Console.WriteLine(cena.Descricao);
        Console.WriteLine();
    }
}