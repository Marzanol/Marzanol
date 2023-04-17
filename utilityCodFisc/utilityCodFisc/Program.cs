using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("Inserisci il tuo cognome: ");
        string cognome = Console.ReadLine().ToUpper();

        Console.Write("Inserisci il tuo nome: ");
        string nome = Console.ReadLine().ToUpper();

        Console.Write("Inserisci la tua data di nascita (formato AAAA-MM-GG): ");
        DateTime dataNascita = DateTime.Parse(Console.ReadLine());

        Console.Write("Inserisci il tuo genere (M o F): ");
        char genere = Console.ReadLine().ToUpper()[0];

        Console.Write("Inserisci il comune di nascita: ");
        string comune = Console.ReadLine().ToUpper();

        // Calcola il codice fiscale
        string codiceFiscale = CalcolaCodiceFiscale(cognome, nome, dataNascita, genere, comune);

        Console.WriteLine("Il tuo codice fiscale è: " + codiceFiscale);
    }

    static string CalcolaCodiceFiscale(string cognome, string nome, DateTime dataNascita, char genere, string comune)
    {
        // Calcola il codice del comune di nascita
        string codiceComune = CalcolaCodiceComune(comune);

        // Calcola il codice dei caratteri del cognome
        string codiceCognome = CalcolaCodiceCognome(cognome);

        // Calcola il codice dei caratteri del nome
        string codiceNome = CalcolaCodiceNome(nome);

        // Calcola il codice della data di nascita e del genere
        string codiceDataGenere = CalcolaCodiceDataGenere(dataNascita, genere);

        // Calcola il codice fiscale completo
        string codiceFiscale = codiceCognome + codiceNome + codiceDataGenere + codiceComune;

        return codiceFiscale;
    }

    static string CalcolaCodiceFiscale(string cognome, string nome, DateTime dataNascita, char genere, string comune)
    {
        // Calcola il codice del comune di nascita
        string codiceComune = CalcolaCodiceComune(comune);

        // Calcola il codice dei caratteri del cognome
        string codiceCognome = CalcolaCodiceCognome(cognome);

        // Calcola il codice dei caratteri del nome
        string codiceNome = CalcolaCodiceNome(nome);

        // Calcola il codice della data di nascita e del genere
        string codiceDataGenere = CalcolaCodiceDataGenere(dataNascita, genere);

        // Calcola il codice fiscale completo
        string codiceFiscale = codiceCognome + codiceNome + codiceDataGenere + codiceComune;

        return codiceFiscale;
    }

    static string CalcolaCodiceComune(string comune)
    {
        // Calcola il codice del comune di nascita
        // Il codice è composto da una lettera seguita da tre cifre
        // La lettera corrisponde alla prima consonante del nome del comune (se presente), altrimenti alla prima consonante del secondo nome del comune (se presente), altrimenti alla lettera X
        // Le cifre corrispondono al codice catastale del comune (disponibile online o presso il comune stesso)

        string codice = "X000";
        string[] consonanti = { "B", "C", "D", "F", "G", "H", "L", "M", "N", "P", "Q", "R", "S", "T", "V", "Z" };

        comune = comune.Replace(" ", "");

        // Cerca la prima consonante del nome del comune
        foreach (char c in comune)
        {
            string carattere = c.ToString().ToUpper();
            if (Array.Exists(consonanti, consonante => consonante == carattere))
            {
                codice = carattere + codice.Substring(1);
                break;
            }
        }

        // Se non è stata trovata una consonante valida, cerca la prima consonante del secondo nome del comune
        if (codice[0] == 'X';
