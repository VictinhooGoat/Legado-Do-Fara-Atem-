using System.Collections.Generic;

public class Scene
{
    public string Id { get; set; }
    public string Titulo { get; set; }
    public string Descricao { get; set; }

    public List<Choice> Escolhas { get; set; }

    public Scene(string id, string titulo, string descricao)
    {
        Id = id;
        Titulo = titulo;
        Descricao = descricao;
        Escolhas = new List<Choice>();
    }
}
