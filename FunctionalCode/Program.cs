using System.Collections.Generic;

namespace FunctionalCode
{
    using MessageProcessor;
    internal class Program
    {
        public static void Main(string[] args)
        {
            ISmsSenderService smsSenderService = new SmsSenderService();
            IMobileNumberSubscriptionService mobileNumberSubscriptionService = new MobileNumberSubscriptionService();
            INlpParserService nlpParserService = new NlpParserService();
            ITemplateSelectorService templateSelectorService = new TemplateSelectorService();
            var messageProcessor = new MessageProcessor.MessageProcessor(mobileNumberSubscriptionService, nlpParserService,
                templateSelectorService, smsSenderService);
            
            // Fluent interface and Method Chaning. In Functional programming it is called functional composition
            messageProcessor.IsMobileSubscriptionEnabled("123456")
                            .DoNlpProcessing("YES")
                            .SelectTemplate("Affirmative")
                            .SendMessage("You have successfully subscribed to our services");
        }
    }

    internal class SmsSenderService : ISmsSenderService
    {
        public void SendMessage(string smsMessage)
        {
            // Implement your logic for sms sending
            throw new System.NotImplementedException();
        }
    }

    internal class TemplateSelectorService : ITemplateSelectorService
    {
        public IReadOnlyCollection<Template> GetTemplates(string nlpResponse)
        {
            // implement your custom logic for retrivieng templates based on nlp response
            throw new System.NotImplementedException();
        }
    }

    internal class NlpParserService : INlpParserService
    {
        public string ParseSmsMessage(string message)
        {
            // implement your logic for parsing sms message through NLP Engine
            throw new System.NotImplementedException();
        }
    }

    internal class MobileNumberSubscriptionService : IMobileNumberSubscriptionService
    {
        public bool IsMobileNumberEnabledForSubscription(string mobileNumber)
        {
            // Check whether the number is enabled for receiving sms
            throw new System.NotImplementedException();
        }
    }
}