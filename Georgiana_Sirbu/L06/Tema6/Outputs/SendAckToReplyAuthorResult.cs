using System;
using System.Collections.Generic;
using System.Text;

namespace Tema6.Outputs
{
    public static partial class SendAckToReplyAuthorResult
    {
        public interface ISendAskToReplyAuthorResult { };
        public class ReplyPublished:ISendAskToReplyAuthorResult
        {
            public string ConfirmationMsg { get; }
            public ReplyPublished(string confirmationMsg)
            {
                ConfirmationMsg = confirmationMsg;
            }
        }
        public class InvalidReplyPublished : ISendAskToReplyAuthorResult
        {
            public string ErrorMsg { get; }
            public InvalidReplyPublished(string errorMsg)
            {
                ErrorMsg = errorMsg;
            }
        }
    }
}
