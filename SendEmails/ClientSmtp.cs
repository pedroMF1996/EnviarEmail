using System.Net;
using System.Net.Mail;

namespace SendEmails
{
    public class ClientSmtp
    {
        public string Provedor { get; private set; }
        public int Porta { get; private set; }
        public bool HabilitarSsl { get; private set; }
        public int TimeOut { get; private set; }
        public bool UsarCredenciaisPadrao { get; private set; }
        public string Email { get; private set; }
        public string Senha { get; private set; }
        
        private NetworkCredential Credenciais;
        private SmtpClient smtpClient;

        public ClientSmtp(string provedor, int porta, bool habilitarSsl, int timeOut, bool usarCredenciaisPadrao, string email, string senha)
        {
            Provedor = provedor ?? throw new ArgumentNullException(nameof(provedor));
            Porta = porta;
            HabilitarSsl = habilitarSsl;
            TimeOut = timeOut;
            UsarCredenciaisPadrao = usarCredenciaisPadrao;
            Email = email ?? throw new ArgumentNullException(nameof(email));
            Senha = senha ?? throw new ArgumentNullException(nameof(senha));
        }


        public void GerarCredenciais()
        {
            UsarCredenciaisPadrao = false; 
            Credenciais = new NetworkCredential(Email, Senha);
        }

        public void GerarSmtpClient()
        {
            smtpClient = new SmtpClient();
            smtpClient.Host = Provedor;
            smtpClient.Port = Porta;
            smtpClient.EnableSsl = HabilitarSsl;
            smtpClient.UseDefaultCredentials = UsarCredenciaisPadrao;
            smtpClient.Credentials = Credenciais;
            smtpClient.Timeout = TimeOut;
        }

        public void EnviarEmail(MensagemDoEmail email)
        {
            smtpClient.Send(email.CriarMailMessage());
        }
    }
}
