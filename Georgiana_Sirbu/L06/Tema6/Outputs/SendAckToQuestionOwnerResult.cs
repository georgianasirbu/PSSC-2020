using System;
using System.Collections.Generic;
using System.Text;

namespace Tema6.Outputs
{
    public static partial class SendAckToQuestionOwnerResult
    {
        public interface ISendAckToQuestionOwnerResult { };
        public class ReplyReceived:ISendAckToQuestionOwnerResult
        {
            public String Text { get; }
            public ReplyReceived(String text)
            {
                Text = text;
            }
        }
        public class InvalidReplyReceived:ISendAckToQuestionOwnerResult
        {
            public String ErrorMsg { get; }
            public InvalidReplyReceived(String errorMsg)
            {
                ErrorMsg = errorMsg;
            }
        }

    }
}
