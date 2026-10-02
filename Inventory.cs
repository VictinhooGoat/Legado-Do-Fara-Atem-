using System;
using System.Collections.Generic;

public class Inventory
{
    private List<string> itens = new List<string>();

    public void Adicionar(string item)
    {
        if (!itens.Contains(item))
        {
            itens.Add(item);
        }
    }

    public bool Possui(string item)
    {
        return itens.Contains(item);
    }

    public void Mostrar()
    {
        Console.WriteLine();
        Console.WriteLine("========== INVENTÁRIO ==========");

        if (itens.Count == 0)
        {
            Console.WriteLine("Seu inventário está vazio.");
        }
        else
        {
            foreach (string item in itens)
            {
                Console.WriteLine("- " + item);
            }
        }

        Console.WriteLine("================================");
        Console.WriteLine();
        Console.WriteLine("Pressione ESC para voltar.");
    }
}