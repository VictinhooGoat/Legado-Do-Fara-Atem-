using System.Collections.Generic;

public class StoryGraph
{
    public Dictionary<string, Scene> Cenas { get; private set; }

    public StoryGraph()
    {
        Cenas = new Dictionary<string, Scene>();

        CriarCenas();
    }

    private void CriarCenas()
    {
        Scene entrada = new Scene(
            "entrada",
            "Entrada da Tumba",
            "Você finalmente encontra a entrada da tumba perdida. " +
            "Segundo os registros, aqui foram escondidas cartas mágicas " +
            "utilizadas pelos antigos egípcios."
        );

        Scene corredor = new Scene(
            "corredor",
            "Corredor das Serpentes",
            "Um longo corredor coberto por desenhos de serpentes. " +
            "Você escuta um estranho som vindo das paredes."
        );

        Scene biblioteca = new Scene(
            "biblioteca",
            "Biblioteca do Faraó",
            "Centenas de papiros estão espalhados pelo chão. " +
            "Entre eles existe uma carta extremamente antiga."
        );

        Scene tesouro = new Scene(
            "tesouro",
            "Câmara do Tesouro",
            "O brilho dourado de moedas antigas ilumina a sala. " +
            "No centro existe uma caixa protegida por magia."
        );

        Scene templo = new Scene(
            "templo",
            "Templo Secreto",
            "Atrás de uma parede falsa existe um pequeno templo. " +
            "No altar existe uma carta coberta por símbolos."
        );

        Scene tumba = new Scene(
            "tumba",
            "Câmara do Faraó",
            "Você chega ao centro da tumba. " +
            "Um enorme sarcófago está diante de você."
        );

        Scene portal = new Scene(
            "portal",
            "Portal do Duelo",
            "As paredes começam a brilhar. " +
            "Uma energia sobrenatural envolve a sala."
        );

        Scene final = new Scene(
            "final",
            "Câmara Final",
            "Você finalmente encontra o conjunto das cartas lendárias."
        );


        // ==============================
        // ENTRADA
        // ==============================

        entrada.Escolhas.Add(
            new Choice(
                "Entrar no corredor principal",
                "corredor"
            )
        );

        entrada.Escolhas.Add(
            new Choice(
                "Examinar os símbolos da entrada",
                "biblioteca"
            )
        );


        // ==============================
        // CORREDOR
        // ==============================

        corredor.Escolhas.Add(
            new Choice(
                "Seguir para a biblioteca",
                "biblioteca"
            )
        );

        corredor.Escolhas.Add(
            new Choice(
                "Explorar a passagem lateral",
                "tesouro"
            )
        );


        // ==============================
        // BIBLIOTECA
        // ==============================

        biblioteca.Escolhas.Add(
            new Choice(
                "Pesquisar os papiros",
                "templo"
            )
        );

        biblioteca.Escolhas.Add(
            new Choice(
                "Examinar uma passagem secreta",
                "portal"
            )
        );


        // ==============================
        // TESOURO
        // ==============================

        tesouro.Escolhas.Add(
            new Choice(
                "Abrir a caixa mágica",
                "tumba"
            )
        );

        tesouro.Escolhas.Add(
            new Choice(
                "Investigar os símbolos dourados",
                "templo"
            )
        );


        // ==============================
        // TEMPLO
        // ==============================

        templo.Escolhas.Add(
            new Choice(
                "Pegar a carta do altar",
                "tumba"
            )
        );

        templo.Escolhas.Add(
            new Choice(
                "Investigar os hieróglifos",
                "portal"
            )
        );


        // ==============================
        // CÂMARA DO FARAÓ
        // ==============================

        tumba.Escolhas.Add(
            new Choice(
                "Abrir o sarcófago",
                "portal"
            )
        );

        tumba.Escolhas.Add(
            new Choice(
                "Usar o Mago Negro para abrir a passagem",
                "final",
                "Mago Negro"
            )
        );


        // ==============================
        // PORTAL
        // ==============================

        portal.Escolhas.Add(
            new Choice(
                "Aceitar o duelo do faraó",
                "final"
            )
        );


        // ==============================
        // CÂMARA FINAL
        // ==============================

        final.Escolhas.Add(
            new Choice(
                "Escapar da tumba com as cartas",
                "VITORIA"
            )
        );

        final.Escolhas.Add(
            new Choice(
                "Destruir as cartas mágicas",
                "SACRIFICIO"
            )
        );

        final.Escolhas.Add(
            new Choice(
                "Usar as cartas para invocar o faraó",
                "DERROTA"
            )
        );


        // ==============================
        // ADICIONAR CENAS AO GRAFO
        // ==============================

        Cenas.Add(entrada.Id, entrada);
        Cenas.Add(corredor.Id, corredor);
        Cenas.Add(biblioteca.Id, biblioteca);
        Cenas.Add(tesouro.Id, tesouro);
        Cenas.Add(templo.Id, templo);
        Cenas.Add(tumba.Id, tumba);
        Cenas.Add(portal.Id, portal);
        Cenas.Add(final.Id, final);
    }
}