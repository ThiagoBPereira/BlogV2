using System.Configuration;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;

using Twilio;

namespace TBP.Blog.Infra.CrossCutting.Identity.Configuration
{
    public class SmsService : IIdentityMessageService
    {
        public Task SendAsync(IdentityMessage message)
        {
            if (ConfigurationManager.AppSettings["Internet"] == "true")
            {
                // Utilizando TWILIO como SMS Provider.
                // https://www.twilio.com/docs/quickstart/csharp/sms/sending-via-rest

                //Conta criada para teste 
                //TODO 3: Verificar funcionamento do Twilio
                var accountSid = ConfigurationManager.AppSettings["TwilioaccountId"];
                var authToken = ConfigurationManager.AppSettings["TwilioToken"]; ;

                var client = new TwilioRestClient(accountSid, authToken);

                client.SendMessage(ConfigurationManager.AppSettings["TwilioPhoneNumber"], message.Destination, message.Body);
            }

            return Task.FromResult(0);
        }
    }
}
