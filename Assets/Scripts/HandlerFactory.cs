using System;
using Assets.Scripts;
using LOLSocketModel;

internal class HandlerFactory
{
    internal static IReceiveMessage<MessageModel> Create(byte type)
    {
        switch (type)
        {
            case TypeProtocol.LOGIN:
                return new LoginHandler();
            case TypeProtocol.USER:
                return new UserHandler();
            default:
                throw new ErrorTypeException();
        }
    }
}