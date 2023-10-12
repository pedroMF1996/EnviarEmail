using SendEmails;
using System.Text;

try
{
    var email = new MensagemDoEmail("de", "para", "Segundo teste", true, "<p> conteudo da mensagem </p>", Encoding.UTF8, Encoding.UTF8);

	var client = new ClientSmtp("smtp-mail.outlook.com", 587, true, 50000, false, "de", "senha");

	client.GerarCredenciais();
	client.GerarSmtpClient();
	client.EnviarEmail(email);

	Console.WriteLine("Email enviado com sucesso");
	Console.ReadLine();
}
catch (Exception)
{
	Console.WriteLine("O correu um erro");
	Console.ReadLine();
}
