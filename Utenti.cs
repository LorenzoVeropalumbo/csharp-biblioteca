public class Utenti
{
    public Utenti(string cognome, string nome, string email, string password, string recapitoTelefonico)
    {
        Cognome = cognome;
        Nome = nome;
        Email = email;
        Password = password;
        RecapitoTelefonico = recapitoTelefonico;
    }

    public string Cognome { set; get; }
    public string Nome { set; get; }
    public string Email { set; get; }    
    public string Password { set; get; }
    public string RecapitoTelefonico { set; get; }
}