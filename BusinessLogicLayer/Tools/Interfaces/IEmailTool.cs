namespace BusinessLogicLayer.Tools.Interfaces
{
    public interface IEmailTool
    {
        void Send(string from, string toRecipients, string subject, string body);
        void SendFromDefault(string toRecipients, string subject, string body);
        void SendFromUser(int userId, string toRecipients, string subject, string body);
        void SendToUser(int userId, string from, string subject, string body);
        void SendFromDefaultToUser(int userId, string subject, string body);
    }
}
