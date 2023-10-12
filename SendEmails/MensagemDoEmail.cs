using System.Net.Mail;
using System.Text;

namespace SendEmails
{
    public class MensagemDoEmail
    {
        public string De { get; private set; }
        public string Para { get; private set; }
        public bool CorpoEhHtml { get; private set; }
        public string Conteudo { get; private set; }
        public string Titulo { get; private set; }
        public Encoding TituloEncoding { get; private set; }
        public Encoding ConteudoEncoding { get; private set; }

        public MensagemDoEmail(string de, string para, string titulo, bool corpoEhHtml, string conteudo, Encoding tituloEncoding, Encoding conteudoEncoding)
        {
            De = de ?? throw new ArgumentNullException(nameof(de));
            Para = para ?? throw new ArgumentNullException(nameof(para));
            CorpoEhHtml = corpoEhHtml;
            Conteudo = conteudo ?? throw new ArgumentNullException(nameof(conteudo));
            Titulo = titulo ?? throw new ArgumentNullException(nameof(titulo));
            TituloEncoding = tituloEncoding ?? throw new ArgumentNullException(nameof(tituloEncoding));
            ConteudoEncoding = conteudoEncoding ?? throw new ArgumentNullException(nameof(conteudoEncoding));
        }

        public MailMessage CriarMailMessage()
        {
            return new MailMessage(De,Para)
                        {
                            IsBodyHtml = CorpoEhHtml,
                            Subject = Titulo,
                            Body = Conteudo,
                            SubjectEncoding = TituloEncoding,
                            BodyEncoding = ConteudoEncoding
                        };
        }

    }
}