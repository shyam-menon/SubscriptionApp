namespace SubscriptionApp.API.Infrastructure.Email
{
    public class EmailServiceFactory
    {
        private static IEmailService _emailService;

        public static void InitializeEmailServiceFactory(IEmailService emailService)
        {
            _emailService = emailService;
        }

        public static IEmailService GetEmailService()
        {
            return _emailService;
        }
    }
}