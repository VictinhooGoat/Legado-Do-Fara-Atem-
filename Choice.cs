public class Choice
{
    public string Texto { get; set; }
    public string ProximaCena { get; set; }
    public string ItemNecessario { get; set; }

    public Choice(string texto, string proximaCena, string itemNecessario = "")
    {
        Texto = texto;
        ProximaCena = proximaCena;
        ItemNecessario = itemNecessario;
    }
}