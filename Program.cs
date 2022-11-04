using System;
using System.Diagnostics;
using System.Reflection.PortableExecutable;

Bilblioteca Bilblioteca = new Bilblioteca();
Bilblioteca.GenerateDocuments();
Bilblioteca.GenerateUser();

bool loop = true;
while (loop)
{
    //Console.WriteLine("Il Tuo Credito è di : " + credito + "gettoni");
    //Chiedo all'utente cosa vuole fare
    Console.WriteLine("Scegli un opzione");
    Console.WriteLine("1) Effettua un prestito");
    Console.WriteLine("2) Mostra i documenti");
    Console.WriteLine("3) Esci");    
    int risposta = Convert.ToInt32(Console.ReadLine());

    switch (risposta)
    {
        case 1:
            Bilblioteca.checkDocument();
            break;
        case 2:
            Bilblioteca.GetAllDocuments();
            break;
        case 3:
            loop = false;
            break;
        default:
            Console.WriteLine("Non è stata selezionata un opzione valida");
            break;
    }
}
public class Bilblioteca
{
    public List<Utenti> utentiList = new List<Utenti>();
    public List<Documenti> DocumentiList = new List<Documenti>();
    public List<Prestito> PrestitoList = new List<Prestito>();

    public void RegistraUtente()
    {
        Console.WriteLine("------- REGISTRATI -------");
        Console.Write("Cognome : "); 
        string cognome = Console.ReadLine();
        Console.Write("Nome : ");
        string nome = Console.ReadLine();
        Console.Write("Email : ");
        string email = Console.ReadLine();
        Console.Write("Password : ");
        string Password = Console.ReadLine();
        Console.Write("RecapitoTelefonico : ");
        string recapitoTelefonico = Console.ReadLine();

        Utenti utenti = new Utenti(cognome, nome, email, Password, recapitoTelefonico);
        utentiList.Add(utenti);
    }

    public void GenerateDocuments()
    {
        Libri spiderman = new Libri("spiderman", 1996, "animazione", true, 15.14f, "Lorenzo Rossi", "13D2324AD4", 70);
        DocumentiList.Add(spiderman);
        Libri batman = new Libri("batman", 1996, "azione", true, 10.2f, "Luca Verdi", "12D455C44A", 70);
        DocumentiList.Add(batman);
        Libri hulk = new Libri("hulk", 1996, "avventura", false, 4.20f, "Marco Gialli", "13D2324AD", 70);
        DocumentiList.Add(hulk);

        DvD cenerentola = new DvD("cenerentola", 1996, "animazione", true, 15.14f, "Lorenzo Rossi", "235F78G2F3", 70);
        DocumentiList.Add(cenerentola);
        DvD biancaneve = new DvD("biancaneve", 1996, "animazione", true, 15.14f, "Lorenzo Rossi", "234DA79NK7", 70);
        DocumentiList.Add(biancaneve);
        DvD godzilla = new DvD("godzilla", 1996, "animazione", false, 15.14f, "Lorenzo Rossi", "87A6FG76T9", 70);
        DocumentiList.Add(godzilla);
    }

    public void GenerateUser()
    {
        Utenti utenti = new Utenti("Veropalumbo", "Lorenzo","lorenzo@email.it", "1234", "333333333");
        Utenti utenti1 = new Utenti("Lo Re", "Giuseppe",  "lorenzo@email.it", "1234", "333333333");
        Utenti utenti2 = new Utenti( "Marra", "Francesco", "lorenzo@email.it", "1234", "333333333");
        Utenti utenti3 = new Utenti("Pisani", "Davide", "lorenzo@email.it", "1234", "333333333");
        utentiList.Add(utenti);
        utentiList.Add(utenti1);
        utentiList.Add(utenti2);
        utentiList.Add(utenti3);
    }

    public void GetAllDocuments()
    {
        foreach (Documenti doc in DocumentiList)
        {
            Console.WriteLine("Titolo : " + doc.Titolo + " - Codice : " + doc.CodiceIdentificativo);
        }
    }

    public void checkDocument()
    {            
        Console.WriteLine("inserisci il Titolo o il Codice Prodotto");
        string ToSearch = Console.ReadLine();
        
        foreach (Documenti doc in DocumentiList)
        {

            if (doc.Titolo == ToSearch || doc.CodiceIdentificativo == ToSearch)
            {
                if (doc.Stato)
                {
                    Console.WriteLine("Titolo : " + doc.Titolo + " - Codice : " + doc.CodiceIdentificativo);
                    Console.WriteLine("Sei Registrato 1 - Si  2 - NO");
                    int risposta = Convert.ToInt32(Console.ReadLine());

                    switch (risposta)
                    {
                        case 1:
                            break;
                        case 2:
                            RegistraUtente();
                            
                            utentiList[utentiList.Count() - 1]
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Documento momentaneamente non disponibile premi invio uscire");
                    Console.ReadLine();
                    return;
                }
                
            }
        }
    }
}

public class Prestito
{
    public Prestito(string dataInizio, string dataFine, Documenti documentoPrestato, Utenti utentePrestito)
    {
        DataInizio = dataInizio;
        DataFine = dataFine;
        this.documentoPrestato = documentoPrestato;
        UtentePrestito = utentePrestito;
    }

    public string DataInizio { get; set; }
    public string DataFine { get; set; }
    Documenti documentoPrestato { get; set; }
    Utenti UtentePrestito { get; set; }

    public Prestito GetPrestito(string dataInizio, string dataFine, Documenti documentoPrestato, Utenti utentePrestito)
    {
        Prestito prestito = new Prestito(dataInizio, dataFine, documentoPrestato, utentePrestito);
        return prestito;
    }
}

public class Documenti
{
    public Documenti(string titolo, int anno, string settore, bool stato, double scaffale, string autore, string codiceIdentificativo)
    {
        Titolo = titolo;
        Anno = anno;
        Settore = settore;
        Stato = stato;
        Scaffale = scaffale;
        Autore = autore;
        CodiceIdentificativo = codiceIdentificativo;
    }

    public string CodiceIdentificativo { set; get; }
    public string Titolo { set; get; }
    public int Anno { set; get; }
    public string Settore { set; get; }
    public bool Stato { set; get; }
    public double Scaffale { set; get; }
    public string Autore { set; get; }

}
