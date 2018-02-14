namespace FunctionalCode.MessageProcessor
{
    public interface IMessageProcessor
    {
        IMessageProcessor IsMobileSubscriptionEnabled(string mobileNumber);
        IMessageProcessor DoNlpProcessing(string smsText);
        IMessageProcessor SelectTemplate(string messageResponseFromNlp);
        void SendMessage(string messageTemplate);
    }
}