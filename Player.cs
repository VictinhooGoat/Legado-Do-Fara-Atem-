public class Player
{
    public int Vida { get; set; }
    public int Bateria { get; set; }
    public int Sanidade { get; set; }

    public Player()
    {
        Vida = 100;
        Bateria = 100;
        Sanidade = 100;
    }
}