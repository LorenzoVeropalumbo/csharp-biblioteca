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
    Console.WriteLine("3) Cerca Prestiti");
    Console.WriteLine("4) Esci");    
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
            Bilblioteca.GetPrestito();
            break;
        case 4:
            loop = false;
            break;
        default:
            Console.WriteLine("Non è stata selezionata un opzione valida");
            break;
    }
}
