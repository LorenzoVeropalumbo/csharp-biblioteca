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
    public Documenti documentoPrestato { get; set; }
    public Utenti UtentePrestito { get; set; }
}
