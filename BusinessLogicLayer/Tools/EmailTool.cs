using System;
using System.Collections.Generic;
using System.Text;

using DTOTbl = BusinessLogicLayer.DataTransferObjects.Tables;

using BusinessLogicLayer.Infrastructure;
using BusinessLogicLayer.Tools.Interfaces;
using BusinessLogicLayer.Tools.Holders;

namespace BusinessLogicLayer.Tools
{
    // default 
    public class EmailTool
    {
        private EMailGateway _gateway;
        private IUserTool _userTool;
        public EmailTool()
        {
            _gateway = new EMailGateway();
            _userTool = UserToolHolder.Get();
        }

        public void SendFromDefault(string toRecipients, string subject, string body)
        {
            _gateway.SendFromDefault(toRecipients, subject, body);
        }

        public void SendFromDefaultToUser(int userId, string subject, string body)
        {
            DTOTbl.User currUser = _userTool.Read1(userId);
            string toRecipients = currUser.Email;
            SendFromDefault(toRecipients, subject, body);
        }
    }
}
