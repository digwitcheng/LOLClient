using System;
using LOLSocketModel;

namespace Assets.Scripts
{
    internal class ErrorHandler : AbsMessageHandler
    {
        public override void Receive(MessageModel model)
        {
            throw new NotImplementedException();
        }
    }
}