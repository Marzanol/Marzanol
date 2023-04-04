
{
    static void Main(string[] args)
    {
        // Istanzia un oggetto ExpressionParser
        ExpressionParser parser = new ExpressionParser();

        // Recupera il testo da Console.ReadLine()
        Console.WriteLine("Inserisci l'espressione da calcolare:");
        string expression = Console.ReadLine();

        // Esegui il metodo ExecuteCalc dell'oggetto parser
        double result = parser.ExecuteCalc(expression);

        // Visualizza il risultato
        Console.WriteLine("Il risultato è: " + result);
    }
}

}