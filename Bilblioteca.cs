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
        Utenti utenti = new Utenti("Veropalumbo", "Lorenzo", "lorenzo@email.it", "1234", "333333333");
        Utenti utenti1 = new Utenti("Lo Re", "Giuseppe", "lorenzo@email.it", "1234", "333333333");
        Utenti utenti2 = new Utenti("Marra", "Francesco", "lorenzo@email.it", "1234", "333333333");
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
        Console.WriteLine();
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
                            GetUtente(doc);
                            break;
                        default:
                            RegistraUtente();
                            Console.Write("Data Inizio : ");
                            string inizio = Console.ReadLine();
                            Console.Write("Data Fine : ");
                            string fine = Console.ReadLine();
                            Prestito prestito = new Prestito(inizio, fine, doc, utentiList[utentiList.Count() - 1]);
                            PrestitoList.Add(prestito);
                            doc.Stato = false;
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Documento momentaneamente non disponibile premi invio uscire");
                    Console.Read();
                    return;
                }

            }
        }
    }

    public void GetUtente(Documenti doc)
    {
        Console.Write("Cognome : ");
        string cognome = Console.ReadLine();
        Console.Write("Nome : ");
        string nome = Console.ReadLine();

        foreach (Utenti item in utentiList)
        {
            if (nome == item.Nome && cognome == item.Cognome)
            {
                Console.Write("Data Inizio : ");
                string inizio = Console.ReadLine();
                Console.Write("Data Fine : ");
                string fine = Console.ReadLine();
                Prestito prestito = new Prestito(inizio, fine, doc, item);
                PrestitoList.Add(prestito);
                doc.Stato = false;
            }
        }
    }

    public void GetPrestito()
    {
        Console.Write("Cognome : ");
        string cognome = Console.ReadLine();
        Console.Write("Nome : ");
        string nome = Console.ReadLine();

        foreach (Prestito item in PrestitoList)
        {
            if (nome == item.UtentePrestito.Nome && cognome == item.UtentePrestito.Cognome)
            {
                Console.WriteLine(item.UtentePrestito.Cognome + " " + item.UtentePrestito.Nome + " ha preso in prestito " + item.documentoPrestato.Titolo);
            }
        }
    }
}
