using System;
using System.Collections.Generic;
using System.Reflection;

namespace FunctionalCode.MessageProcessor
{
    class MessageProcessor : IMessageProcessor
    {
        private readonly IMobileNumberSubscriptionService _mobileNumberSubscriptionService;
        private readonly INlpParserService _nlpParserService;
        private readonly ITemplateSelectorService _templateSelectorService;
        private readonly ISmsSenderService _smsSenderService;


        public MessageProcessor(IMobileNumberSubscriptionService mobileNumberSubscriptionService, 
                                INlpParserService nlpParserService,
                                ITemplateSelectorService templateSelectorService,
                                ISmsSenderService smsSenderService)
        {
            _mobileNumberSubscriptionService = mobileNumberSubscriptionService;
            _nlpParserService = nlpParserService;
            _templateSelectorService = templateSelectorService;
            _smsSenderService = smsSenderService;
        }

        public IMessageProcessor IsMobileSubscriptionEnabled(string mobileNumber)
        {
            _mobileNumberSubscriptionService.IsMobileNumberEnabledForSubscription(mobileNumber);
            return this;
        }

        public IMessageProcessor DoNlpProcessing(string smsText)
        {
            _nlpParserService.ParseSmsMessage(smsText);
            return this;
        }

        public IMessageProcessor SelectTemplate(string messageResponseFromNlp)
        {
            _templateSelectorService.GetTemplates(messageResponseFromNlp);
            return this;
        }

        public void SendMessage(string messageTemplate)
        {
            _smsSenderService.SendMessage(messageTemplate);
        }
    }

    public interface IMobileNumberSubscriptionService
    {
        bool IsMobileNumberEnabledForSubscription(string mobileNumber);
    }

    public interface INlpParserService
    {
        string ParseSmsMessage(string message);
    }

    public interface ITemplateSelectorService
    {
        IReadOnlyCollection<Template> GetTemplates(string nlpResponse);
    }

    public class Template
    {
        public Template(string body, int id)
        {
            Body = body;
            Id = id;
        }

        private int Id { get; }
        private string Body { get; }
    }

    public interface ISmsSenderService
    {
        void SendMessage(string smsMessage);
    }
}