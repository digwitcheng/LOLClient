using System;
using LOLSocketModel;

namespace Assets.Scripts
{
    internal class ErrorHandler : IReceiveMessage<MessageModel>
    {
        public void Receive(MessageModel model,Action<object> action)
        {
            throw new NotImplementedException();
        }
    }
}