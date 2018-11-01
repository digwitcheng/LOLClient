using LOLSocketModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts
{
    class ReceiveMessageFactory
    {
        public static IReceiveMessage<MessageModel> CreateReceiveMessage(MessageModel model)
        {
            switch (model.Type)
            {
                case TypeProtocol.LOGIN:
                    return new LoginMessageHandler();
                default:
                    return new ErrorHandler();
            }
        }
    }
}
